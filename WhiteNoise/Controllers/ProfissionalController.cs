using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Profissional;

namespace WhiteNoise.Controllers
{
    //[Authorize]
    public class ProfissionalController : BaseController
    {
        #region Private Fields
        private readonly IMapper _mapper; 
        private readonly IProfissionalRepository _profissionalRepository;

        #endregion

        #region Constructors
        public ProfissionalController(IMapper mapper, IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profissionais = await _profissionalRepository.ObterTodos();
            var profissionaisViewModel = _mapper.Map<List<ProfissionalViewModel>>(profissionais);
            return View(profissionaisViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            var profissional = await _profissionalRepository.ObterPorId(id);
            var profissionalViewModel = _mapper.Map<ProfissionalViewModel>(profissional);
            return View(profissionalViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }        

        [HttpPost]
        public async Task<IActionResult> Create(ProfissionalViewModel profissionalViewModel)
        {
            if (ModelState.IsValid)
            {
                var profissional = _mapper.Map<Profissional>(profissionalViewModel);
                profissional.Id = Guid.NewGuid();
                await _profissionalRepository.Adicionar(profissional);
                return RedirectToAction(nameof(Index));

            }
            return View(profissionalViewModel);
        }
                
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var profissional = await _profissionalRepository.ObterPorId(id);

            if (profissional == null)
                return NotFound();

            var profissionalViewModel = _mapper.Map<ProfissionalViewModel>(profissional);

            return View(profissionalViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProfissionalViewModel profissionalViewModel)
        {
            if (id != profissionalViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var profissional = _mapper.Map<Profissional>(profissionalViewModel);
                    await _profissionalRepository.Atualizar(profissional);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_profissionalRepository.ObterPorId(id).Result == null)
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

            return View(profissionalViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var profissional = await _profissionalRepository.ObterPorId(id);

            if (profissional == null)
            {
                return NotFound();
            }

            var profissionalViewModel = _mapper.Map<ProfissionalViewModel>(profissional);

            return View(profissionalViewModel);
        }
                
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _profissionalRepository.Remover(id);
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
