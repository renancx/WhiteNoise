using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Prontuario;

namespace WhiteNoise.Controllers
{
    public class ProntuarioController : BaseController
    {
        #region Private Fields
        private readonly IProntuarioRepository _agendamentoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public ProntuarioController(IMapper mapper, 
            IProntuarioRepository agendamentoRepository,
            INotyfService notyf,
            IPacienteRepository pacienteRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _notyf = notyf;
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
        }

        #endregion

        #region Private Methods
        private async Task PopularPacientes(ProntuarioFormModel model)
        {
            var estados = await _pacienteRepository.ObterTodos();
            model.Pacientes = new SelectList(estados, "Id", "Nome", model.PacienteId);
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var agendamentos = await _agendamentoRepository.ObterTodos();
            var agendamentosGridModel = _mapper.Map<List<ProntuarioGridModel>>(agendamentos);
            return View(agendamentosGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);
            var agendamentoGridModel = _mapper.Map<ProntuarioGridModel>(agendamento);
            return View(agendamentoGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProntuarioFormModel();
            await PopularPacientes(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProntuarioFormModel agendamentoFormModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularPacientes(agendamentoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(agendamentoFormModel);
            }
            var agendamento = _mapper.Map<Prontuario>(agendamentoFormModel);

            agendamento.Id = Guid.NewGuid();
            await _agendamentoRepository.Adicionar(agendamento);
            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);

            if (agendamento == null)
                return NotFound();

            var agendamentoFormModel = _mapper.Map<ProntuarioFormModel>(agendamento);
            await PopularPacientes(agendamentoFormModel);
            return View(agendamentoFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProntuarioFormModel agendamentoFormModel)
        {
            if (id != agendamentoFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopularPacientes(agendamentoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(agendamentoFormModel);
            }

            try
            {
                var agendamento = _mapper.Map<Prontuario>(agendamentoFormModel);
                await _agendamentoRepository.Atualizar(agendamento);
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
            var agendamento = await _agendamentoRepository.ObterPorId(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            var agendamentoGridModel = _mapper.Map<ProntuarioGridModel>(agendamento);

            return View(agendamentoGridModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _agendamentoRepository.Remover(id);
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
