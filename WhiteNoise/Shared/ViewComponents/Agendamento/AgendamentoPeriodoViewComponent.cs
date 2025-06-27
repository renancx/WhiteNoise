using System;
using Microsoft.AspNetCore.Mvc;
using WhiteNoise.Infra.Data.Contexts;
using WhiteNoise.Models.Shared;
using WhiteNoise.Shared.Helpers;

namespace WhiteNoise.Shared.ViewComponents.Agendamento
{
    public class AgendamentoPeriodoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoPeriodoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(DateTime? diaInicio = null, DateTime? diaFinal = null)
        {
            var inicio = diaInicio?.Date ?? DateTime.Today;
            var fim = diaFinal?.Date ?? inicio.AddDays(1);

            var totalPorPeriodo = AgendamentoHelper.ObterTotalizadorAgendamentosPorPeriodo(_context, inicio, fim);

            var model = new ContadorViewModel
            {
                Contador = totalPorPeriodo
            };

            return View(model);
        }
    }
}
