using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Infra.Data.Contexts;
using WhiteNoise.Helpers;
using WhiteNoise.Models.EstadoClinico;

namespace WhiteNoise.ViewComponents.EstadoClinico
{
    public class EstadoClinicoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public EstadoClinicoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string estado)
        {
            var totalGeral = Totalizador.ObterTotalizadorPaciente(_context);
            decimal totalEstadoClinico = Totalizador.ObterTotalPacientesPorEstadoClinico(_context, estado);
            decimal progresso = (totalGeral > 0) ? (totalEstadoClinico * 100) / totalGeral : 0;
            var percentual = progresso.ToString("F1");

            var model = new EstadoClinicoContadorModel
            {
                Titulo = $"Estado {estado}",
                Percentual = percentual,
                Parcial = (int)totalEstadoClinico,
                Progresso = progresso
            };

            return View(model);
        }
    }
}
