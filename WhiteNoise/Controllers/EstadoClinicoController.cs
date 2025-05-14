using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Controllers
{
    public class EstadoClinicoController : Controller
    {
        #region Private Fields
        private readonly IEstadoClinicoRepository _estadoClinicoRepository;

        #endregion

        #region Constructors
        public EstadoClinicoController(IEstadoClinicoRepository estadoClinicoRepository)
        {
            _estadoClinicoRepository = estadoClinicoRepository;
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var estadosClinicos = await _estadoClinicoRepository.ObterTodos();
            return View(estadosClinicos);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var estadoClinico = await _estadoClinicoRepository.ObterPorId(id);
            return View(estadoClinico);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EstadoClinico estadoClinico)
        {
            if (ModelState.IsValid)
            {
                estadoClinico.Id = Guid.NewGuid();
                await _estadoClinicoRepository.Adicionar(estadoClinico);
                return RedirectToAction(nameof(Index));
            }
            return View(estadoClinico);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var estadoClinico = await _estadoClinicoRepository.ObterPorId(id);

            if (estadoClinico == null)
                return NotFound();

            return View(estadoClinico);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EstadoClinico estadoClinico)
        {
            if (id != estadoClinico.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                try {
                    await _estadoClinicoRepository.Atualizar(estadoClinico);
                } 
                catch(DbUpdateConcurrencyException) {
                    if (_estadoClinicoRepository.ObterPorId(id).Result == null)
                    {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estadoClinico);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var estadoClinico = await _estadoClinicoRepository.ObterPorId(id);

            if (estadoClinico == null) {
                return NotFound();
            }
            else {
                return View(estadoClinico);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try {
                await _estadoClinicoRepository.Remover(id);
            } 
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
