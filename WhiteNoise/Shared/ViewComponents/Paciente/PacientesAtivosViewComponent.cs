using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Infra.Data.Contexts;
using WhiteNoise.Models.Shared;
using WhiteNoise.Shared.Helpers;

namespace WhiteNoise.Shared.ViewComponents.Leito
{
    public class PacientesAtivosViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PacientesAtivosViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var pacientesAtivos = PacienteHelper.ObterTotalizadorPacientesAtivos(_context);

            var model = new ContadorViewModel
            {
                Contador = pacientesAtivos,
            };

            return View(model);
        }
    }
}