using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Domain.Extensions;
using WhiteNoise.Infra.Data.Contexts;
using WhiteNoise.Models.Leito;
using WhiteNoise.Shared.Helpers;

namespace WhiteNoise.Shared.ViewComponents.Leito
{
    public class LeitoContadorViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public LeitoContadorViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(StatusLeitoEnum status)
        {
            var totalGeral = LeitoHelper.ObterTotalizadorLeitos(_context);
            var totalLeitos = LeitoHelper.ObterTotalLeitosPorStatus(_context, status);
            var percentual = totalGeral > 0 ? totalLeitos * 100 / totalGeral : 0;

            var model = new LeitoContadorViewModel
            {
                Status = status.GetDisplayName(),
                Quantidade = totalLeitos,
                Percentual = percentual,
            };

            return View(model);
        }
    }
}