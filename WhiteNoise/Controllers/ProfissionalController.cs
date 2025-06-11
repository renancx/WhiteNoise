using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Repositories;
using WhiteNoise.Models.Leito;
using WhiteNoise.Models.Profissional;
namespace WhiteNoise.Controllers
{
    //[Authorize]
    public class ProfissionalController : BaseController
    {
        #region Private Fields
        private readonly IMapper _mapper; 
        private readonly IProfissionalRepository _profissionalRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly INotyfService _notyf;

        #endregion

        #region Constructors
        public ProfissionalController(IMapper mapper, IProfissionalRepository profissionalRepository, INotyfService notyf, IDepartamentoRepository departamentoRepository)
        {
            _profissionalRepository = profissionalRepository;
            _mapper = mapper;
            _notyf = notyf;
            _departamentoRepository = departamentoRepository;
        }
        #endregion

        private async Task PopularDepartamentos(ProfissionalViewModel model)
        {
            var departamentos = await _departamentoRepository.ObterTodos();
            model.Departamentos = new SelectList(departamentos, "Id", "Descricao", model.DepartamentoId);
        }

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profissionais = await _profissionalRepository.ObterTodos();
            var profissionaisGridModel = _mapper.Map<List<ProfissionalGridModel>>(profissionais);
            return View(profissionaisGridModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            var profissional = await _profissionalRepository.ObterPorId(id);
            var profissionalViewModel = _mapper.Map<ProfissionalViewModel>(profissional);
            return View(profissionalViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProfissionalViewModel();
            await PopularDepartamentos(model);

            return View(model);
        }        

        [HttpPost]
        public async Task<IActionResult> Create(ProfissionalViewModel profissionalViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularDepartamentos(profissionalViewModel);
                _notyf.Error("Ocorreu um erro ao salvar as informações.");
                return View(profissionalViewModel);
            }

            var profissional = _mapper.Map<Profissional>(profissionalViewModel);
            profissional.Id = Guid.NewGuid();

            await _profissionalRepository.Adicionar(profissional);

            _notyf.Success("As informações foram salvas com sucesso.");
            return RedirectToAction(nameof(Index));            
        }
                
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var profissional = await _profissionalRepository.ObterPorId(id);

            if (profissional == null)
                return NotFound();

            var profissionalViewModel = _mapper.Map<ProfissionalViewModel>(profissional);
            await PopularDepartamentos(profissionalViewModel);
            return View(profissionalViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProfissionalViewModel profissionalViewModel)
        {
            if (id != profissionalViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await PopularDepartamentos(profissionalViewModel);
                _notyf.Error("Preencha todas as informações obrigatórias.");
                return View(profissionalViewModel);
            }

            try
            {
                var profissional = _mapper.Map<Profissional>(profissionalViewModel);
                await _profissionalRepository.Atualizar(profissional);
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
            var profissional = await _profissionalRepository.ObterPorId(id);

            if (profissional == null)
            {
                return NotFound();
            }

            var profissionalViewModel = _mapper.Map<ProfissionalViewModel>(profissional);

            return View(profissionalViewModel);
        }
                
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _profissionalRepository.Remover(id);
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
