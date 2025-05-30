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
        public InternacaoController(IMapper mapper, 
            IInternacaoRepository internacaoRepository, 
            IPacienteRepository pacienteRepository,
            ILeitoRepository leitoRepository,
            INotyfService notyf)
        {
            _internacaoRepository = internacaoRepository;
            _pacienteRepository = pacienteRepository;
            _leitoRepository = leitoRepository;
            _notyf = notyf;
            _mapper = mapper;
        }

        #endregion

        #region Private Methods

        private async Task PopularSelectListsInternacao(InternacaoFormModel model) 
        {
            var pacientes = await _pacienteRepository.ObterTodos();
            var leitos = await _leitoRepository.ObterPorStatusOuId(model.LeitoId, StatusLeitoEnum.Livre);

            model.Pacientes = new SelectList(pacientes, "Id", "Nome", model.PacienteId);
            model.Leitos = new SelectList(leitos, "Id", "Descricao", model.LeitoId);
        }

        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            var internacoes = await _internacaoRepository.ObterTodos();
            var internacoesGridModel = _mapper.Map<List<InternacaoGridModel>>(internacoes);
            return View(internacoesGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var internacao = await _internacaoRepository.ObterPorId(id);
            var internacaoGridModel = _mapper.Map<InternacaoGridModel>(internacao);
            return View(internacaoGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new InternacaoFormModel { };

            await PopularSelectListsInternacao(model);

            return View(model);
        }

        [HttpPost]
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

                await _leitoRepository.AtualizarStatus(internacao.LeitoId, StatusLeitoEnum.Ocupado);

                internacao.Id = Guid.NewGuid();
                await _internacaoRepository.Adicionar(internacao);
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
            var internacao = await _internacaoRepository.ObterPorId(id);

            if (internacao == null)
                return NotFound();

            var internacaoFormModel = _mapper.Map<InternacaoFormModel>(internacao);
            await PopularSelectListsInternacao(internacaoFormModel);
            return View(internacaoFormModel);
        }

        [HttpPost]
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
                await _leitoRepository.AtualizarStatus(internacao.LeitoId, StatusLeitoEnum.Ocupado);
                await _internacaoRepository.Atualizar(internacao);
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
            var internacao = await _internacaoRepository.ObterPorId(id);

            if (internacao == null)
            {
                return NotFound();
            }

            var internacaoGridModel = _mapper.Map<InternacaoGridModel>(internacao);

            return View(internacaoGridModel);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _internacaoRepository.Remover(id);
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
