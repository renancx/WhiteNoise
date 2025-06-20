using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Departamento;

namespace WhiteNoise.Controllers
{
    public class DepartamentoController : BaseController
    {
        #region Private Fields
        private readonly IDepartamentoService _departamentoService;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;


        #endregion

        #region Constructors
        public DepartamentoController(IMapper mapper, 
            IDepartamentoService departamentoService,
            INotyfService notyf)
        {
            _departamentoService = departamentoService;
            _notyf = notyf;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var departamentos = await _departamentoService.ObterTodos();
            var departamentosGridModel = _mapper.Map<List<DepartamentoGridModel>>(departamentos);
            return View(departamentosGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var departamento = await _departamentoService.ObterPorId(id);
            var departamentoFormModel = _mapper.Map<DepartamentoFormModel>(departamento);
            return View(departamentoFormModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartamentoFormModel departamentoFormModel)
        {
            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(departamentoFormModel);

            }
            var departamento = _mapper.Map<Departamento>(departamentoFormModel);
            await _departamentoService.Adicionar(departamento);
            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var departamento = await _departamentoService.ObterPorId(id);

            if (departamento == null)
                return NotFound();

            var departamentoFormModel = _mapper.Map<DepartamentoFormModel>(departamento);

            return View(departamentoFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, DepartamentoFormModel departamentoFormModel)
        {
            if (id != departamentoFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(departamentoFormModel);
            }

            try
            {
                var departamento = _mapper.Map<Departamento>(departamentoFormModel);
                await _departamentoService.Atualizar(departamento);
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
            var departamento = await _departamentoService.ObterPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            var departamentoFormModel = _mapper.Map<DepartamentoFormModel>(departamento);

            return View(departamentoFormModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _departamentoService.Remover(id);
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
