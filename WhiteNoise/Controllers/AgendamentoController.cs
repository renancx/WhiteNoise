using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Agendamento;

namespace WhiteNoise.Controllers
{
    public class AgendamentoController : BaseController
    {
        #region Private Fields
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public AgendamentoController(IMapper mapper, IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            //var agendamentos = await _agendamentoRepository.ObterTodos();            
            //var agendamentosViewModel = _mapper.Map<List<AgendamentoViewModel>>(agendamentos);
            //return View(agendamentosViewModel);

            var agendamentos = await _agendamentoRepository.ObterTodos();
            var agendamentosViewModel = _mapper.Map<List<AgendamentoViewModel>>(agendamentos);
            return View(agendamentosViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);
            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(agendamento);
            return View(agendamentoViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgendamentoViewModel agendamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoViewModel);
                agendamento.Id = Guid.NewGuid();
                await _agendamentoRepository.Adicionar(agendamento);
                return RedirectToAction(nameof(Index));

            }
            return View(agendamentoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);

            if (agendamento == null)
                return NotFound();

            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(agendamento);

            return View(agendamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AgendamentoViewModel agendamentoViewModel)
        {
            if (id != agendamentoViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var agendamento = _mapper.Map<Agendamento>(agendamentoViewModel);
                    await _agendamentoRepository.Atualizar(agendamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_agendamentoRepository.ObterPorId(id).Result == null)
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

            return View(agendamentoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(agendamento);

            return View(agendamentoViewModel);

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
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
