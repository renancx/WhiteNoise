using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Paciente;

namespace WhiteNoise.Controllers
{
    public class PacienteController : BaseController
    {
        #region Private Fields
        private readonly IMapper _mapper;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IEstadoClinicoRepository _estadoClinicoRepository;
        private readonly INotyfService _notyf;

        #endregion

        #region Constructors
        public PacienteController(IMapper mapper, 
            IPacienteRepository pacienteRepository, 
            IEstadoClinicoRepository estadoClinicoRepository, 
            INotyfService notyf)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
            _estadoClinicoRepository = estadoClinicoRepository;
            _notyf = notyf;
        }

        #endregion

        #region Private Methods
        private async Task PopularEstadosClinicos(PacienteFormModel model)
        {
            var estados = await _estadoClinicoRepository.ObterTodos();
            model.EstadosClinicos = new SelectList(estados, "Id", "Descricao", model.EstadoClinicoId);
        }

        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteRepository.ObterTodos();
            var pacientesViewModel = _mapper.Map<List<PacienteGridModel>>(pacientes);
            return View(pacientesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            var paciente = await _pacienteRepository.ObterPorId(id);
            var pacienteGridModel = _mapper.Map<PacienteGridModel>(paciente);
            return View(pacienteGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> ObterPacientesPorEstadoClinico(Guid? id)
        {
            var paciente = await _pacienteRepository.ObterPorEstadoClinicoId(id);
            var pacienteFormModel = _mapper.Map<PacienteFormModel>(paciente);
            return View(pacienteFormModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new PacienteFormModel();
            await PopularEstadosClinicos(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteFormModel pacienteFormModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularEstadosClinicos(pacienteFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(pacienteFormModel);
            }

            var paciente = _mapper.Map<Paciente>(pacienteFormModel);
            
            paciente.Id = Guid.NewGuid();
            await _pacienteRepository.Adicionar(paciente);
            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var paciente = await _pacienteRepository.ObterPorId(id);

            if (paciente == null)
                return NotFound();

            var pacienteFormModel = _mapper.Map<PacienteFormModel>(paciente);
            await PopularEstadosClinicos(pacienteFormModel);
            return View(pacienteFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PacienteFormModel pacienteFormModel)
        {
            if (id != pacienteFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopularEstadosClinicos(pacienteFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(pacienteFormModel);
            }

            try
            {
                var paciente = _mapper.Map<Paciente>(pacienteFormModel);
                await _pacienteRepository.Atualizar(paciente);
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
            var paciente = await _pacienteRepository.ObterPorId(id);

            if (paciente == null)
            {
                return NotFound();
            }

            var pacienteGridModel = _mapper.Map<PacienteGridModel>(paciente);

            return View(pacienteGridModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _pacienteRepository.Remover(id);
            }
            catch
            {
                _notyf.Error("Ocorreu um erro ao deletar o registro.");
                return RedirectToAction(nameof(Index));
            }

            _notyf.Success("As informações foram deletadas com sucesso.");
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
