using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Infra.Data.Contexts;
using WhiteNoise.Models.Shared;
using WhiteNoise.Shared.Helpers;

namespace WhiteNoise.Shared.ViewComponents.Leito
{
    public class InternacoesAtivasViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public InternacoesAtivasViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var internacoesAtivas = InternacaoHelper.ObterTotalizadorInternacoesAtivas(_context);

            var model = new ContadorViewModel
            {
                Contador = internacoesAtivas,
            };

            return View(model);
        }
    }
}