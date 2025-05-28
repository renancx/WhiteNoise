using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Prontuario;

namespace WhiteNoise.Controllers
{
    public class ProntuarioController : BaseController
    {
        #region Private Fields
        private readonly IProntuarioRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public ProntuarioController(IMapper mapper, IProntuarioRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
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
            var agendamentoFormModel = _mapper.Map<ProntuarioFormModel>(agendamento);
            return View(agendamentoFormModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProntuarioFormModel agendamentoFormModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Prontuario>(agendamentoFormModel);
                agendamento.Id = Guid.NewGuid();
                await _agendamentoRepository.Adicionar(agendamento);
                return RedirectToAction(nameof(Index));

            }
            return View(agendamentoFormModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);

            if (agendamento == null)
                return NotFound();

            var agendamentoFormModel = _mapper.Map<ProntuarioFormModel>(agendamento);

            return View(agendamentoFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProntuarioFormModel agendamentoFormModel)
        {
            if (id != agendamentoFormModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var agendamento = _mapper.Map<Prontuario>(agendamentoFormModel);
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

            return View(agendamentoFormModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var agendamento = await _agendamentoRepository.ObterPorId(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            var agendamentoFormModel = _mapper.Map<ProntuarioFormModel>(agendamento);

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
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
