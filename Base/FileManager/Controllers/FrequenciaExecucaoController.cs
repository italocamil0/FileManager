using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileManager.Business.Models;
using FileManager.Data.Context;

namespace FileManager.Controllers
{
    public class FrequenciaExecucaoController : Controller
    {
        private readonly MeuDbContext _context;

        public FrequenciaExecucaoController(MeuDbContext context)
        {
            _context = context;
        }

        // GET: FrequenciaExecucao
        public async Task<IActionResult> Index()
        {
            return View(await _context.FrequenciaExecucao.ToListAsync());
        }

        // GET: FrequenciaExecucao/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frequenciaExecucao = await _context.FrequenciaExecucao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frequenciaExecucao == null)
            {
                return NotFound();
            }

            return View(frequenciaExecucao);
        }

        // GET: FrequenciaExecucao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FrequenciaExecucao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Frequencia,Id")] FrequenciaExecucao frequenciaExecucao)
        {
            if (ModelState.IsValid)
            {
                frequenciaExecucao.Id = Guid.NewGuid();
                _context.Add(frequenciaExecucao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frequenciaExecucao);
        }

        // GET: FrequenciaExecucao/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frequenciaExecucao = await _context.FrequenciaExecucao.FindAsync(id);
            if (frequenciaExecucao == null)
            {
                return NotFound();
            }
            return View(frequenciaExecucao);
        }

        // POST: FrequenciaExecucao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Frequencia,Id")] FrequenciaExecucao frequenciaExecucao)
        {
            if (id != frequenciaExecucao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frequenciaExecucao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrequenciaExecucaoExists(frequenciaExecucao.Id))
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
            return View(frequenciaExecucao);
        }

        // GET: FrequenciaExecucao/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frequenciaExecucao = await _context.FrequenciaExecucao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frequenciaExecucao == null)
            {
                return NotFound();
            }

            return View(frequenciaExecucao);
        }

        // POST: FrequenciaExecucao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var frequenciaExecucao = await _context.FrequenciaExecucao.FindAsync(id);
            _context.FrequenciaExecucao.Remove(frequenciaExecucao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrequenciaExecucaoExists(Guid id)
        {
            return _context.FrequenciaExecucao.Any(e => e.Id == id);
        }
    }
}
