using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Controllers
{
    //[Authorize]
    public class EstadoClinicoController : BaseController
    {
        #region Private Fields
        private readonly IEstadoClinicoRepository _estadoClinicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly INotyfService _notyf;

        #endregion

        #region Constructors
        public EstadoClinicoController(IEstadoClinicoRepository estadoClinicoRepository, IPacienteRepository pacienteRepository, INotyfService notyf)
        {
            _estadoClinicoRepository = estadoClinicoRepository;
            _notyf = notyf;
            _pacienteRepository = pacienteRepository;
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
            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(estadoClinico);
            }

            estadoClinico.Id = Guid.NewGuid();
            await _estadoClinicoRepository.Adicionar(estadoClinico);
            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));
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

            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(estadoClinico);
            }

            try
            {
                await _estadoClinicoRepository.Atualizar(estadoClinico);
            } 
            catch 
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                throw;                
            }

            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));            
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
            var pacientes = await _pacienteRepository.ObterPorEstadoClinicoId(id);

            if (pacientes != null && pacientes.Any())
            {
                _notyf.Success("Não é possível deletar o registro.");
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _estadoClinicoRepository.Remover(id);
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
