using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Infra.Data.Contexts;
using WhiteNoise.Models.Shared;
using WhiteNoise.Shared.Helpers;

namespace WhiteNoise.Shared.ViewComponents.Leito
{
    public class ProfissionaisAtivosViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ProfissionaisAtivosViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var profissionaisAtivos = ProfissionalHelper.ObterTotalizadorProfissionaisAtivos(_context);

            var model = new ContadorViewModel
            {
                Contador = profissionaisAtivos,
            };

            return View(model);
        }
    }
}