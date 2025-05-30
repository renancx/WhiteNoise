using System;
using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Infra.Data.Contexts;
using WhiteNoise.Models.Leito;
using WhiteNoise.Shared.Helpers;

namespace WhiteNoise.Shared.ViewComponents.Leito
{
    public class LeitoOcupacaoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public LeitoOcupacaoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(Guid? leitoId)
        {
            var internacao= LeitoHelper.ObterInternacaoDoLeito(_context, leitoId);

            var model = new LeitoOcupacaoViewModel
            {
                Paciente = internacao.Paciente.Nome,
                DataEntrada = internacao.DataEntrada,
                EstadoClinico = internacao.Paciente.EstadoClinico?.Descricao
            };

            return View(model);
        }
    }
}