using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Agendamento;

namespace WhiteNoise.Controllers
{
    public class AgendamentoController : BaseController
    {
        #region Private Fields
        private readonly IAgendamentoService _agendamentoService;
        private readonly IProfissionalService _profissionalService;
        private readonly IPacienteService _pacienteService;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public AgendamentoController(IMapper mapper, 
            IAgendamentoService agendamentoService, 
            IPacienteService pacienteService, 
            IProfissionalService profissionalService,
            INotyfService notyf)
        {
            _agendamentoService = agendamentoService;
            _profissionalService = profissionalService;
            _pacienteService = pacienteService;
            _notyf = notyf;
            _mapper = mapper;
        }

        #endregion

        #region Private Methods

        private async Task PopularSelectListsAgendamento(AgendamentoFormModel model)
        {
            var pacientes = await _pacienteService.ObterTodos();
            var profissionais = await _profissionalService.ObterTodos();

            model.Pacientes = new SelectList(pacientes, "Id", "Nome", model.PacienteId);
            model.Profissionais = new SelectList(profissionais, "Id", "Nome", model.ProfissionalId);
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var agendamentos = await _agendamentoService.ObterTodos();



            var agendamentosGridModel = _mapper.Map<List<AgendamentoGridModel>>(agendamentos);
            return View(agendamentosGridModel);
        }

        public async Task<IActionResult> Calendario()
        {
            var agendamentos = await _agendamentoService.ObterTodos();
            var agendamentosGridModel = _mapper.Map<List<AgendamentoGridModel>>(agendamentos);
            return View(agendamentosGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var agendamento = await _agendamentoService.ObterPorId(id);
            var agendamentoGridModel = _mapper.Map<AgendamentoGridModel>(agendamento);
            return View(agendamentoGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new AgendamentoFormModel { };

            await PopularSelectListsAgendamento(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgendamentoFormModel agendamentoFormModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularSelectListsAgendamento(agendamentoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(agendamentoFormModel);
            }

            var agendamento = _mapper.Map<Agendamento>(agendamentoFormModel);

            agendamento.Id = Guid.NewGuid();
            await _agendamentoService.Adicionar(agendamento);
            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Calendario));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agendamento = await _agendamentoService.ObterPorId(id);

            if (agendamento == null)
                return NotFound();

            var agendamentoFormModel = _mapper.Map<AgendamentoFormModel>(agendamento);
            await PopularSelectListsAgendamento(agendamentoFormModel);
            return View(agendamentoFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AgendamentoFormModel agendamentoFormModel)
        {
            if (id != agendamentoFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopularSelectListsAgendamento(agendamentoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(agendamentoFormModel);
            }

            try
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoFormModel);
                await _agendamentoService.Atualizar(agendamento);
            }
            catch
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                return RedirectToAction(nameof(Index));
            }

            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Calendario));            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var agendamento = await _agendamentoService.ObterPorId(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            var agendamentoGridModel = _mapper.Map<AgendamentoGridModel>(agendamento);

            return View(agendamentoGridModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _agendamentoService.Remover(id);
            }
            catch (Exception ex)
            {
                _notyf.Error("Ocorreu um erro ao deletar o registro.");
                return BadRequest(ex.Message);
            }

            _notyf.Success("As informações foram deletadas com sucesso.");

            return RedirectToAction(nameof(Calendario));
        }

        #endregion
    }
}
