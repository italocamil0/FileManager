using AutoMapper;
using FileManager.App.WebApp.Models;
using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Core.Application.Port;
using FileManager.Infra.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.App.WebApp.Controllers
{
    public class ArquivosController : Controller
    {
        private readonly MeuDbContext _context;
        private readonly IMapper _mapper;

        private readonly IArquivosPort _arquivosPort;
        private readonly IFrequenciaExecucaoPort _frequenciaExecucaoPort;
        private readonly IPrefixoPort _prefixoPort;        
        private readonly ISendMessagePort _sendMessagePort;
        private readonly ICamposPort _camposPort;        

        public ArquivosController(MeuDbContext context, IMapper mapper, IArquivosPort arquivosPort, IFrequenciaExecucaoPort frequenciaExecucaoPort, IPrefixoPort prefixoPort, ISendMessagePort sendMessagePort, ICamposPort camposPort)
        {
            _context = context;
            _mapper = mapper;
            _arquivosPort = arquivosPort;
            _frequenciaExecucaoPort = frequenciaExecucaoPort;
            _prefixoPort = prefixoPort;
            _sendMessagePort = sendMessagePort;
            _camposPort = camposPort;
        }

        // GET: ArquivosController
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {           
            return View(_mapper.Map<IEnumerable<ArquivoViewModel>>(await _arquivosPort.ObterArquivosFrequenciasPrefixos()));
        }

        // GET: ArquivosController/Details/5
        public ActionResult Details(Guid id)
        {
            var viewModel = _mapper.Map<ArquivoViewModel>(_arquivosPort.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault());
            viewModel.FrequenciaExecucao = _mapper.Map<FrequenciaExecucaoViewModel>(_frequenciaExecucaoPort.Buscar(x => x.Id == viewModel.FrequenciaExecucaoId).Result.FirstOrDefault());
            return View(viewModel);
        }

        public ActionResult Run(Guid id)
        {
            var arquivo = _arquivosPort.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault();

            arquivo.Campos = _camposPort.Buscar(x => x.Arquivo.Id == id).Result;
            arquivo.Campos.OrderBy(x => x.DataRegistro);

            arquivo.Prefixo = _prefixoPort.Buscar(x => x.Id == arquivo.PrefixoId).Result.FirstOrDefault();

            _sendMessagePort.SendMessageAsync(arquivo);

            return RedirectToAction(nameof(Index));
        }

        // GET: ArquivosController/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFrequenciasExecucao(new ArquivoViewModel());
            await PopularPrefixos(produtoViewModel);

            return View(produtoViewModel);
        }

        // POST: ArquivosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArquivoViewModel viewModel)
        {
            await PopularFrequenciasExecucao(viewModel);
            await PopularPrefixos(viewModel);

            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                if (ModelState.IsValid)
                {
                    LimparFrequencia(viewModel);
                    var arquivo = _mapper.Map<Arquivo>(viewModel);
                    arquivo.Id = Guid.NewGuid();
                    arquivo.FrequenciaExecucao = null;
                    await _arquivosPort.Adicionar(arquivo);                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCampo(ArquivoViewModel arquivo)
        {            
            arquivo.Campos.Add(new CampoViewModel());
            return PartialView("_CamposArquivo", arquivo);
        }

        private void LimparFrequencia(ArquivoViewModel viewModel)
        {
            var frequencia = _frequenciaExecucaoPort.ObterPorId(Guid.Parse(viewModel.FrequenciaExecucaoId.ToString())).Result;

            switch (frequencia.Frequencia)
            {
                case "DIÁRIO":

                    viewModel.Dia1 = 0;
                    viewModel.Dia2 = 0;
                    viewModel.DiaDaSemana = null;
                    break;
                case "SEMANAL":

                    viewModel.Dia1 = 0;
                    viewModel.Dia2 = 0;
                    break;
                case "QUINZENAL":

                    viewModel.DiaDaSemana = null;
                    break;
                case "MENSAL":

                    viewModel.Dia2 = 0;
                    viewModel.DiaDaSemana = null;
                    break;
                default:
                    break;
            }
        }

        // GET: ArquivosController/Edit/5
        public async Task<ActionResult> EditAsync(Guid id)
        {
            var viewModel = _mapper.Map<ArquivoViewModel>(_arquivosPort.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault());
           
            await PopularFrequenciasExecucao(viewModel);
            await PopularPrefixos(viewModel);

            viewModel.Campos = _mapper.Map<List<CampoViewModel>>(_camposPort.Buscar(x => x.Arquivo.Id == id).Result);

            viewModel.Campos.OrderBy(x => x.DataRegistro);
            
            return View(viewModel);
        }

        // POST: ArquivosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(string id, ArquivoViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LimparFrequencia(viewModel);
                    
                    await PopularFrequenciasExecucao(viewModel);
                    await PopularPrefixos(viewModel);
                    var arquivoBase = _mapper.Map<Arquivo>(viewModel);                    
                    await _arquivosPort.Atualizar(arquivoBase);
                }
                else
                {
                    return View(viewModel);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
        }        

        // GET: ArquivosController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var viewModel = _mapper.Map<ArquivoViewModel>(_arquivosPort.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault());
            viewModel.FrequenciaExecucao = _mapper.Map<FrequenciaExecucaoViewModel>(_frequenciaExecucaoPort.Buscar(x => x.Id == viewModel.FrequenciaExecucaoId).Result.FirstOrDefault());
            return View(viewModel);
        }

        // POST: ArquivosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ArquivoViewModel viewModel)
        {
            var campos = _camposPort.Buscar(x => x.Arquivo.Id == viewModel.Id).Result.ToList();

            foreach (var campo in campos)
            {
                await _camposPort.Remover(campo.Id);
            }

            await _arquivosPort.Remover(viewModel.Id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<ArquivoViewModel> PopularFrequenciasExecucao(ArquivoViewModel arquivo)
        {
            arquivo.FrequenciasExecucao = _mapper.Map<IEnumerable<FrequenciaExecucaoViewModel>>(await _frequenciaExecucaoPort.ObterTodos());
            return arquivo;
        }

        private async Task<ArquivoViewModel> PopularPrefixos(ArquivoViewModel arquivo)
        {
            arquivo.Prefixos = _mapper.Map<IEnumerable<PrefixoViewModel>>(await _prefixoPort.ObterTodos());
            return arquivo;
        }
    }
}
