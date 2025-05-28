using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public DepartamentoController(IMapper mapper, IDepartamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
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
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Departamento>(agendamentoFormModel);
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

            var agendamentoFormModel = _mapper.Map<DepartamentoFormModel>(agendamento);

            return View(agendamentoFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, DepartamentoFormModel agendamentoFormModel)
        {
            if (id != agendamentoFormModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var agendamento = _mapper.Map<Departamento>(agendamentoFormModel);
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
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
