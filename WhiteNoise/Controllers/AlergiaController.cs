using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Alergia;

namespace WhiteNoise.Controllers
{
    public class AlergiaController : BaseController
    {
        #region Private Fields
        private readonly IAlergiaRepository _alergiaRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public AlergiaController(IMapper mapper, IAlergiaRepository alergiaRepository)
        {
            _alergiaRepository = alergiaRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            //var alergias = await _alergiaRepository.ObterTodos();            
            //var alergiasViewModel = _mapper.Map<List<AlergiaViewModel>>(alergias);
            //return View(alergiasViewModel);

            var alergias = await _alergiaRepository.ObterTodos();
            var alergiasViewModel = _mapper.Map<List<AlergiaViewModel>>(alergias);
            return View(alergiasViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var alergia = await _alergiaRepository.ObterPorId(id);
            var alergiaViewModel = _mapper.Map<AlergiaViewModel>(alergia);
            return View(alergiaViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlergiaViewModel alergiaViewModel)
        {
            if (ModelState.IsValid)
            {
                var alergia = _mapper.Map<Alergia>(alergiaViewModel);
                alergia.Id = Guid.NewGuid();
                await _alergiaRepository.Adicionar(alergia);
                return RedirectToAction(nameof(Index));

            }
            return View(alergiaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var alergia = await _alergiaRepository.ObterPorId(id);

            if (alergia == null)
                return NotFound();

            var alergiaViewModel = _mapper.Map<AlergiaViewModel>(alergia);

            return View(alergiaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AlergiaViewModel alergiaViewModel)
        {
            if (id != alergiaViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var alergia = _mapper.Map<Alergia>(alergiaViewModel);
                    await _alergiaRepository.Atualizar(alergia);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_alergiaRepository.ObterPorId(id).Result == null)
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

            return View(alergiaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var alergia = await _alergiaRepository.ObterPorId(id);

            if (alergia == null)
            {
                return NotFound();
            }

            var alergiaViewModel = _mapper.Map<AlergiaViewModel>(alergia);

            return View(alergiaViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _alergiaRepository.Remover(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
