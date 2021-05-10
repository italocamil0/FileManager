using AutoMapper;
using FileManager.App.WebApp.Models;
using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Core.Application.Port;
using FileManager.Infra.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IArquivosRepository _arquivosRepository;
        private readonly IFrequenciaExecucaoRepository _frequenciaExecucaoRepository;
        private readonly IPrefixoRepository _prefixoRepository;
        private readonly ISendMessagePort _sendMessagePort;
        private readonly ICamposRepository _camposRepository;



        public ArquivosController(MeuDbContext context, IMapper mapper, IArquivosRepository arquivosRepository, IFrequenciaExecucaoRepository frequenciaExecucaoRepository, IPrefixoRepository prefixoRepository, ISendMessagePort sendMessagePort, ICamposRepository camposRepository)
        {
            _context = context;
            _mapper = mapper;
            _arquivosRepository = arquivosRepository;
            _frequenciaExecucaoRepository = frequenciaExecucaoRepository;
            _prefixoRepository = prefixoRepository;
            _sendMessagePort = sendMessagePort;
            _camposRepository = camposRepository;
        }

        // GET: ArquivosController
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //var meuDbContext = _context.Arquivos.Include(a => a.User).Include(d => d.DetalheArquivoFrequencia);
            //_context.DetalheArquivoFrequencia.Include(f => f.FrequenciasExecucao);            
            var teste3 = await _arquivosRepository.ObterArquivosFrequenciasPrefixos();
            return View(_mapper.Map<IEnumerable<ArquivoViewModel>>(await _arquivosRepository.ObterArquivosFrequenciasPrefixos()));
        }

        // GET: ArquivosController/Details/5
        public ActionResult Details(Guid id)
        {
            var viewModel = _mapper.Map<ArquivoViewModel>(_arquivosRepository.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault());
            viewModel.FrequenciaExecucao = _mapper.Map<FrequenciaExecucaoViewModel>(_frequenciaExecucaoRepository.Buscar(x => x.Id == viewModel.FrequenciaExecucaoId).Result.FirstOrDefault());
            return View(viewModel);
        }

        public ActionResult Run(Guid id)
        {
            var arquivo = _arquivosRepository.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault();

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
                    await _arquivosRepository.Adicionar(arquivo);
                    //_context.Arquivos.Add(arquivo);
                    //_context.DetalheArquivoFrequencia.Add(new DetalheArquivoFrequencia() { ArquivoId = arquivo.Id, FrequenciaExecucaoId = viewModel.FrequenciaExecucaoId.Value, Horario = viewModel.FrequenciaExecucao.Horario, Dia1 = viewModel.FrequenciaExecucao.Dia1, Dia2 = viewModel.FrequenciaExecucao.Dia2, DiaDaSemana = viewModel.FrequenciaExecucao.DiaDaSemana });
                    //await _context.SaveChangesAsync();
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
            var frequencia = _frequenciaExecucaoRepository.ObterPorId(Guid.Parse(viewModel.FrequenciaExecucaoId.ToString())).Result;

            //viewModel.FrequenciaExecucao = new FrequenciaExecucaoViewModel();
            //viewModel.FrequenciaExecucao = _mapper.Map<FrequenciaExecucaoViewModel>(frequencia);

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
            var viewModel = _mapper.Map<ArquivoViewModel>(_arquivosRepository.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault());
           

            await PopularFrequenciasExecucao(viewModel);
            await PopularPrefixos(viewModel);



            viewModel.Campos = _mapper.Map<List<CampoViewModel>>(_camposRepository.Buscar(x => x.Arquivo.Id == id).Result);

            viewModel.Campos.OrderBy(x => x.DataRegistro);
            //var teste = await _arquivosRepository.ObterDetalheArquivoFrequencia(viewModel.Id);

            //viewModel.DetalheArquivoFrequencia =  _mapper.Map<DetalheArquivoFrequenciaViewModel>(teste);

            //viewModel.FrequenciaExecucaoId = viewModel.DetalheArquivoFrequencia.FrequenciaExecucaoId;

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
                    await _arquivosRepository.Atualizar(arquivoBase);
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
            var viewModel = _mapper.Map<ArquivoViewModel>(_arquivosRepository.Buscar(x => x.Id == id).Result.ToList().FirstOrDefault());
            viewModel.FrequenciaExecucao = _mapper.Map<FrequenciaExecucaoViewModel>(_frequenciaExecucaoRepository.Buscar(x => x.Id == viewModel.FrequenciaExecucaoId).Result.FirstOrDefault());
            return View(viewModel);
        }

        // POST: ArquivosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ArquivoViewModel viewModel)
        {
            var campos = _camposRepository.Buscar(x => x.Arquivo.Id == viewModel.Id).Result.ToList();

            foreach (var campo in campos)
            {
                await _camposRepository.Remover(campo.Id);
            }

            await _arquivosRepository.Remover(viewModel.Id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<ArquivoViewModel> PopularFrequenciasExecucao(ArquivoViewModel arquivo)
        {
            arquivo.FrequenciasExecucao = _mapper.Map<IEnumerable<FrequenciaExecucaoViewModel>>(await _frequenciaExecucaoRepository.ObterTodos());
            return arquivo;
        }

        private async Task<ArquivoViewModel> PopularPrefixos(ArquivoViewModel arquivo)
        {
            arquivo.Prefixos = _mapper.Map<IEnumerable<PrefixoViewModel>>(await _prefixoRepository.ObterTodos());
            return arquivo;
        }
    }
}
