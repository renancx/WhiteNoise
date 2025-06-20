using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Leito;

namespace WhiteNoise.Controllers
{
    public class LeitoController : BaseController
    {
        #region Private Fields
        private readonly ILeitoService _leitoService;
        private readonly IDepartamentoService _departamentoService;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;

        #endregion

        #region Constructors
        public LeitoController(IMapper mapper, 
            ILeitoService leitoService,
            INotyfService notyf,
            IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
            _leitoService = leitoService;
            _notyf = notyf;
            _mapper = mapper;
        }

        #endregion

        #region Private Methods
        private async Task PopularDepartamentos(LeitoFormModel model)
        {
            var departamentos = await _departamentoService.ObterTodos();
            model.Departamentos = new SelectList(departamentos, "Id", "Descricao", model.DepartamentoId);
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var leitos = await _leitoService.ObterTodos();
            var leitosGridModel = _mapper.Map<List<LeitoGridModel>>(leitos);
            return View(leitosGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var leito = await _leitoService.ObterPorId(id);
            var leitoGridModel = _mapper.Map<LeitoGridModel>(leito);
            return View(leitoGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new LeitoFormModel();
            await PopularDepartamentos(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeitoFormModel leitoFormModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularDepartamentos(leitoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(leitoFormModel);
            }

            try
            {
                var leito = _mapper.Map<Leito>(leitoFormModel);

                await _leitoService.Adicionar(leito);
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var leito = await _leitoService.ObterPorId(id);

            if (leito == null)
                return NotFound();

            var leitoFormModel = _mapper.Map<LeitoFormModel>(leito);
            await PopularDepartamentos(leitoFormModel);
            return View(leitoFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, LeitoFormModel leitoFormModel)
        {
            if (id != leitoFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopularDepartamentos(leitoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(leitoFormModel);
            }

            try
            {
                var leito = _mapper.Map<Leito>(leitoFormModel);
                await _leitoService.Atualizar(leito);
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
            var leito = await _leitoService.ObterPorId(id);

            if (leito == null)
            {
                return NotFound();
            }

            var leitoGridModel = _mapper.Map<LeitoGridModel>(leito);

            return View(leitoGridModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _leitoService.Remover(id);
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
