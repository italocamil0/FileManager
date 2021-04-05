﻿using AutoMapper;
using FileManager.App.WebApp.Models;
using FileManager.Core.Application.DTOs;
using FileManager.Core.Application.Persistence;
using FileManager.Infra.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public ArquivosController(MeuDbContext context, IMapper mapper, IArquivosRepository arquivosRepository, IFrequenciaExecucaoRepository frequenciaExecucaoRepository, IPrefixoRepository prefixoRepository  )
        {
            _context = context;
            _mapper = mapper;
            _arquivosRepository = arquivosRepository;
            _frequenciaExecucaoRepository = frequenciaExecucaoRepository;
            _prefixoRepository = prefixoRepository;
        }

        // GET: ArquivosController
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var meuDbContext = _context.Arquivos.Include(a => a.User);
            return View(_mapper.Map<IEnumerable<ArquivoViewModel>>(await _arquivosRepository.ObterTodos()));
        }

        // GET: ArquivosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                    var arquivo = _mapper.Map<Arquivo>(viewModel);
                    arquivo.Id = Guid.NewGuid();
                    _context.Arquivos.Add(arquivo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
            return View(viewModel);
        }

        // GET: ArquivosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArquivosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArquivosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArquivosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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