using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Models.Internacao;

namespace WhiteNoise.Controllers
{
    public class InternacaoController : BaseController
    {
        #region Private Fields
        private readonly IInternacaoService _internacaoService;
        private readonly IPacienteService _pacienteService;
        private readonly ILeitoService _leitoService;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        #endregion

        #region Constructors
        public InternacaoController(
            IMapper mapper,
            IInternacaoService internacaoService,
            IPacienteService pacienteService,
            ILeitoService leitoService,
            INotyfService notyf)
        {
            _internacaoService = internacaoService;
            _pacienteService = pacienteService;
            _leitoService = leitoService;
            _mapper = mapper;
            _notyf = notyf;
        }
        #endregion

        #region Private Methods

        private async Task PopularSelectListsInternacao(InternacaoFormModel model)
        {
            var pacientes = await _pacienteService.ObterTodos();
            model.Pacientes = new SelectList(pacientes, "Id", "Nome", model.PacienteId);

            var leitos = await _leitoService.ObterPorStatusOuId(model.LeitoId, StatusLeitoEnum.Livre);
            model.Leitos = new SelectList(leitos, "Id", "Descricao", model.LeitoId);
        }

        #endregion

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            var internacoes = await _internacaoService.ObterTodasAtivas();
            var gridModel = _mapper.Map<List<InternacaoGridModel>>(internacoes);
            return View(gridModel);
        }

        public async Task<IActionResult> Historico()
        {
            var internacoes = await _internacaoService.ObterHistorico();
            var gridModel = _mapper.Map<List<InternacaoHistoricoGridModel>>(internacoes);
            return View(gridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var internacao = await _internacaoService.ObterPorId(id);
            if (internacao is null)
                return NotFound();

            var viewModel = _mapper.Map<InternacaoGridModel>(internacao);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new InternacaoFormModel
            {
                DataEntrada = DateTime.Today
            };

            await PopularSelectListsInternacao(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InternacaoFormModel internacaoFormModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularSelectListsInternacao(internacaoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(internacaoFormModel);
            }

            try
            {
                var internacao = _mapper.Map<Internacao>(internacaoFormModel);
                var prontuario = _mapper.Map<Prontuario>(internacaoFormModel);

                internacao.Prontuario = prontuario;

                await _leitoService.AtualizarStatus(internacaoFormModel.LeitoId, StatusLeitoEnum.Ocupado);
                await _internacaoService.Adicionar(internacao);

                _notyf.Success("As informações foram salvas com sucesso.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var internacao = await _internacaoService.ObterPorId(id);
            if (internacao is null)
                return NotFound();

            var internacaoFormModel = _mapper.Map<InternacaoFormModel>(internacao);

            await PopularSelectListsInternacao(internacaoFormModel);
            return View(internacaoFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, InternacaoFormModel internacaoFormModel)
        {
            if (id != internacaoFormModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopularSelectListsInternacao(internacaoFormModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(internacaoFormModel);
            }

            try
            {
                var internacao = _mapper.Map<Internacao>(internacaoFormModel);
                var prontuario = _mapper.Map<Prontuario>(internacaoFormModel);

                internacao.Prontuario = prontuario;

                await _leitoService.AtualizarStatus(internacao.LeitoId, StatusLeitoEnum.Ocupado);
                await _internacaoService.Atualizar(internacao);

                _notyf.Success("As informações foram atualizadas com sucesso.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var internacao = await _internacaoService.ObterPorId(id);
            if (internacao is null)
                return NotFound();

            var gridModel = _mapper.Map<InternacaoGridModel>(internacao);
            return View(gridModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var internacao = await _internacaoService.ObterPorId(id);
                await _leitoService.AtualizarStatus(internacao.LeitoId , StatusLeitoEnum.Livre);

                await _internacaoService.Remover(id);
                _notyf.Success("As informações foram deletadas com sucesso.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _notyf.Error("Ocorreu um erro ao deletar o registro.");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Finalizar(Guid id)
        {
            var internacao = await _internacaoService.ObterPorId(id);
            if (internacao is null)
                return NotFound();

            var internacaoFinalizarModel = _mapper.Map<InternacaoFinalizarModel>(internacao);

            internacaoFinalizarModel.DataAlta = DateTime.Now;

            return View(internacaoFinalizarModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalizar(Guid id, InternacaoFinalizarModel internacaoFinalizarModel)
        {
            if (id != internacaoFinalizarModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(internacaoFinalizarModel);
            }

            try
            {                
                await _internacaoService.FinalizarPorId(id, internacaoFinalizarModel.TipoSaida, internacaoFinalizarModel.DataAlta);
                await _leitoService.AtualizarStatus(internacaoFinalizarModel.LeitoId , StatusLeitoEnum.Livre);

                _notyf.Success("As informações foram atualizadas com sucesso.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion
    }
}
