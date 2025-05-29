using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Departamento;

namespace WhiteNoise.Controllers
{
    public class DepartamentoController : BaseController
    {
        #region Private Fields
        private readonly IDepartamentoRepository _agendamentoRepository;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;


        #endregion

        #region Constructors
        public DepartamentoController(IMapper mapper, 
            IDepartamentoRepository agendamentoRepository,
            INotyfService notyf)
        {
            _agendamentoRepository = agendamentoRepository;
            _notyf = notyf;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var agendamentos = await _agendamentoRepository.ObterTodos();
            var agendamentosGridModel = _mapper.Map<List<DepartamentoGridModel>>(agendamentos);
            return View(agendamentosGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);
            var agendamentoFormModel = _mapper.Map<DepartamentoFormModel>(agendamento);
            return View(agendamentoFormModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartamentoFormModel agendamentoFormModel)
        {
            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(agendamentoFormModel);

            }
            var agendamento = _mapper.Map<Departamento>(agendamentoFormModel);
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

            var agendamentoFormModel = _mapper.Map<DepartamentoFormModel>(agendamento);

            return View(agendamentoFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, DepartamentoFormModel agendamentoFormModel)
        {
            if (id != agendamentoFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(agendamentoFormModel);
            }

            try
            {
                var agendamento = _mapper.Map<Departamento>(agendamentoFormModel);
                await _agendamentoRepository.Atualizar(agendamento);
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
            var agendamento = await _agendamentoRepository.ObterPorId(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            var agendamentoFormModel = _mapper.Map<DepartamentoFormModel>(agendamento);

            return View(agendamentoFormModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _agendamentoRepository.Remover(id);
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
