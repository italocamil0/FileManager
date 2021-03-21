using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileManager.Business.Models;
using FileManager.Data.Context;
using FileManager.Models;
using AutoMapper;
using FileManager.Business.Interfaces;

namespace FileManager.Controllers
{
    public class ArquivoController : Controller
    {
        private readonly MeuDbContext _context;
        private readonly IFrequenciaExecucaoRepository _frequenciaExecucaoRepository;
        private readonly IArquivoRepository _arquivorepository;
        private readonly IMapper _mapper;

        public ArquivoController(MeuDbContext context,IMapper mapper, IFrequenciaExecucaoRepository frequenciaExecucaoRepository, IArquivoRepository arquivorepository)
        {
            _context = context;
            _mapper = mapper;
            _frequenciaExecucaoRepository = frequenciaExecucaoRepository;
            _arquivorepository = arquivorepository;
        }

        // GET: Arquivo
        public async Task<IActionResult> Index()
        {
            var meuDbContext = _context.Arquivos.Include(a => a.User);
            return View(_mapper.Map<IEnumerable<ArquivoViewModel>>(await _arquivorepository.ObterTodos()));
        }

        // GET: Arquivo/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            return View(arquivo);
        }

        // GET: Arquivo/Create
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFrequenciasExecucao(new ArquivoViewModel());
            return View(produtoViewModel);
        }

        // POST: Arquivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArquivoViewModel arquivoViewModel)
        {
            arquivoViewModel = await PopularFrequenciasExecucao(arquivoViewModel);
            if (!ModelState.IsValid) return View(arquivoViewModel);

            if (ModelState.IsValid)
            {

                var arquivo = _mapper.Map<Arquivo>(arquivoViewModel);
                arquivo.Id = Guid.NewGuid();
                _context.Add(arquivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", arquivoViewModel.UserId);
            return View(arquivoViewModel);
        }

        // GET: Arquivo/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos.FindAsync(id);
            if (arquivo == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", arquivo.UserId);
            return View(arquivo);
        }

        // POST: Arquivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Tabela,Esquema,Prefixo,Posicional,Divisor,FrequenciaExecucao,DiaExecucao1,DiaExecucao2,UserId,Id")] Arquivo arquivo)
        {
            if (id != arquivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arquivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArquivoExists(arquivo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", arquivo.UserId);
            return View(arquivo);
        }

        // GET: Arquivo/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            return View(arquivo);
        }

        // POST: Arquivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var arquivo = await _context.Arquivos.FindAsync(id);
            _context.Arquivos.Remove(arquivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArquivoExists(Guid id)
        {
            return _context.Arquivos.Any(e => e.Id == id);
        }

        private async Task<ArquivoViewModel> PopularFrequenciasExecucao(ArquivoViewModel arquivo)
        {
            arquivo.FrequenciasExecucao = _mapper.Map<IEnumerable<FrequenciaExecucaoViewModel>>(await _frequenciaExecucaoRepository.ObterTodos());
            return arquivo;
        }
    }
}
