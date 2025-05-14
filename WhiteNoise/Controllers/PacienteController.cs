using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        #endregion

        #region Constructors
        public PacienteController(IMapper mapper, IPacienteRepository pacienteRepository, IEstadoClinicoRepository estadoClinicoRepository)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
            _estadoClinicoRepository = estadoClinicoRepository;
        }

        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteRepository.ObterTodos();
            var pacientesViewModel = _mapper.Map<List<PacienteViewModel>>(pacientes);
            return View(pacientesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            var paciente = await _pacienteRepository.ObterPorId(id);
            var pacienteViewModel = _mapper.Map<PacienteViewModel>(paciente);
            return View(pacienteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ObterPacientesPorEstadoClinico(Guid? id)
        {
            var paciente = await _pacienteRepository.ObterPorEstadoClinicoId(id);
            var pacienteViewModel = _mapper.Map<PacienteViewModel>(paciente);
            return View(pacienteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var estados = await _estadoClinicoRepository.ObterTodos();
            ViewBag.EstadosClinicos = new SelectList(estados, "Id", "Descricao");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteViewModel pacienteViewModel)
        {
            if(ModelState.IsValid)
            {
                var paciente = _mapper.Map<Paciente>(pacienteViewModel);
                paciente.Id = Guid.NewGuid();
                await _pacienteRepository.Adicionar(paciente);
                return RedirectToAction(nameof(Index));

            }
            return View(pacienteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var paciente = await _pacienteRepository.ObterPorId(id);

            if (paciente == null)
                return NotFound();

            var estados = await _estadoClinicoRepository.ObterTodos();
            ViewBag.EstadosClinicos = new SelectList(estados, "Id", "Descricao");

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(paciente);

            return View(pacienteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PacienteViewModel pacienteViewModel)
        {
            if (id != pacienteViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var paciente = _mapper.Map<Paciente>(pacienteViewModel);
                    await _pacienteRepository.Atualizar(paciente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_pacienteRepository.ObterPorId(id).Result == null)
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

            return View(pacienteViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var paciente = await _pacienteRepository.ObterPorId(id);

            if (paciente == null)
            {
                return NotFound();
            }

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(paciente);

            return View(pacienteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _pacienteRepository.Remover(id);
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
