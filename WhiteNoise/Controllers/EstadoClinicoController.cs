using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Controllers
{
    //[Authorize]
    public class EstadoClinicoController : BaseController
    {
        #region Private Fields
        private readonly IEstadoClinicoService _estadoClinicoService;
        private readonly IPacienteService _pacienteService;
        private readonly INotyfService _notyf;

        #endregion

        #region Constructors
        public EstadoClinicoController(IEstadoClinicoService estadoClinicoService, IPacienteService pacienteService, INotyfService notyf)
        {
            _estadoClinicoService = estadoClinicoService;
            _notyf = notyf;
            _pacienteService = pacienteService;
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var estadosClinicos = await _estadoClinicoService.ObterTodos();
            return View(estadosClinicos);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var estadoClinico = await _estadoClinicoService.ObterPorId(id);
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
            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(estadoClinico);
            }

            estadoClinico.Id = Guid.NewGuid();
            await _estadoClinicoService.Adicionar(estadoClinico);
            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var estadoClinico = await _estadoClinicoService.ObterPorId(id);

            if (estadoClinico == null)
                return NotFound();

            return View(estadoClinico);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EstadoClinico estadoClinico)
        {
            if (id != estadoClinico.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(estadoClinico);
            }

            try
            {
                await _estadoClinicoService.Atualizar(estadoClinico);
            } 
            catch 
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                return RedirectToAction(nameof(Index));
            }

            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var estadoClinico = await _estadoClinicoService.ObterPorId(id);

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
            var pacientes = await _pacienteService.ObterPorEstadoClinicoId(id);

            if (pacientes != null && pacientes.Any())
            {
                _notyf.Error("Não é possível deletar o registro.");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _estadoClinicoService.Remover(id);
            }
            catch (Exception ex)
            {
                _notyf.Error("Ocorreu um erro ao deletar o registro.");
                return BadRequest(ex.Message);
            }

            _notyf.Success("As informações foram deletadas com sucesso.");
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
