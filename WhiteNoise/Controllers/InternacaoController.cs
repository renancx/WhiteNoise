using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Models.Internacao;

namespace WhiteNoise.Controllers
{
    public class InternacaoController : BaseController
    {
        #region Private Fields
        private readonly IInternacaoRepository _internacaoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ILeitoRepository _leitoRepository;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        #endregion

        #region Constructors
        public InternacaoController(
            IMapper mapper,
            IInternacaoRepository internacaoRepository,
            IPacienteRepository pacienteRepository,
            ILeitoRepository leitoRepository,
            INotyfService notyf)
        {
            _internacaoRepository = internacaoRepository;
            _pacienteRepository = pacienteRepository;
            _leitoRepository = leitoRepository;
            _mapper = mapper;
            _notyf = notyf;
        }
        #endregion

        #region Private Methods

        private async Task PopularSelectListsInternacao(InternacaoFormModel model)
        {
            var pacientes = await _pacienteRepository.ObterTodos();
            model.Pacientes = new SelectList(pacientes, "Id", "Nome", model.PacienteId);

            var leitos = await _leitoRepository.ObterPorStatusOuId(model.LeitoId, StatusLeitoEnum.Livre);
            model.Leitos = new SelectList(leitos, "Id", "Descricao", model.LeitoId);
        }

        #endregion

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            var internacoes = await _internacaoRepository.ObterTodasAtivas();
            var gridModels = _mapper.Map<List<InternacaoGridModel>>(internacoes);
            return View(gridModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var internacao = await _internacaoRepository.ObterPorId(id);
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

                await _leitoRepository.AtualizarStatus(internacaoFormModel.LeitoId, StatusLeitoEnum.Ocupado);
                await _internacaoRepository.Adicionar(internacao);

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
            var internacao = await _internacaoRepository.ObterPorId(id);
            if (internacao is null)
                return NotFound();

            var vm = _mapper.Map<InternacaoFormModel>(internacao);

            await PopularSelectListsInternacao(vm);
            return View(vm);
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

                await _leitoRepository.AtualizarStatus(internacao.LeitoId, StatusLeitoEnum.Ocupado);
                await _internacaoRepository.Atualizar(internacao);

                _notyf.Success("As informações foram atualizadas com sucesso.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var internacao = await _internacaoRepository.ObterPorId(id);
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
                var internacao = await _internacaoRepository.ObterPorId(id);
                await _leitoRepository.AtualizarStatus(internacao.LeitoId , StatusLeitoEnum.Livre);

                await _internacaoRepository.Remover(id);
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
            var internacao = await _internacaoRepository.ObterPorId(id);
            if (internacao is null)
                return NotFound();

            var vm = _mapper.Map<InternacaoFinalizarModel>(internacao);

            return View(vm);
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
                var internacao = _mapper.Map<Internacao>(internacaoFinalizarModel);

                await _internacaoRepository.FinalizarPorId(id, internacaoFinalizarModel.TipoSaida, internacaoFinalizarModel.DataAlta);
                await _leitoRepository.AtualizarStatus(internacao.LeitoId , StatusLeitoEnum.Livre);
                await _internacaoRepository.Atualizar(internacao);

                _notyf.Success("As informações foram atualizadas com sucesso.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                throw;
            }
        }

        #endregion
    }
}
