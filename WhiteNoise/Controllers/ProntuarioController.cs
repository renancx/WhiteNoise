using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Prontuario;

namespace WhiteNoise.Controllers
{
    public class ProntuarioController : BaseController
    {
        #region Private Fields
        private readonly IProntuarioService _prontuarioService;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public ProntuarioController(IMapper mapper, 
            IProntuarioService prontuarioService,
            INotyfService notyf)
        {
            _prontuarioService = prontuarioService;
            _notyf = notyf;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var prontuario = await _prontuarioService.ObterTodos();
            var prontuarioGridModel = _mapper.Map<List<ProntuarioGridModel>>(prontuario);
            return View(prontuarioGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var prontuario = await _prontuarioService.ObterPorId(id);
            var prontuarioGridModel = _mapper.Map<ProntuarioGridModel>(prontuario);
            return View(prontuarioGridModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProntuarioFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProntuarioFormModel prontuarioFormModel)
        {
            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(prontuarioFormModel);
            }
            var prontuario = _mapper.Map<Prontuario>(prontuarioFormModel);

            prontuario.Id = Guid.NewGuid();
            await _prontuarioService.Adicionar(prontuario);
            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var prontuario = await _prontuarioService.ObterPorId(id);

            if (prontuario == null)
                return NotFound();

            var prontuarioFormModel = _mapper.Map<ProntuarioFormModel>(prontuario);
            return View(prontuarioFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProntuarioFormModel prontuarioFormModel)
        {
            if (id != prontuarioFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(prontuarioFormModel);
            }

            try
            {
                var prontuario = _mapper.Map<Prontuario>(prontuarioFormModel);
                await _prontuarioService.Atualizar(prontuario);
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
            var prontuario = await _prontuarioService.ObterPorId(id);

            if (prontuario == null)
            {
                return NotFound();
            }

            var prontuarioGridModel = _mapper.Map<ProntuarioGridModel>(prontuario);

            return View(prontuarioGridModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _prontuarioService.Remover(id);
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
