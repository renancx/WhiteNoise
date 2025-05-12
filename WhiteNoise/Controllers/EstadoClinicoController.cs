using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Controllers
{
    public class EstadoClinicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadoClinicoController(ApplicationDbContext context)
        {
            _context = context;
        } 

        public async Task<IActionResult> Index()
        {
            var model = await _context.EstadoClinico.ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var estadoClinico = await _context.EstadoClinico.FirstOrDefaultAsync(x => x.Id == id);

            if(estadoClinico != null)
                return View(estadoClinico);

            return BadRequest("Erro ao exibir o registro");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EstadoClinico estadoClinico)
        {
            if (ModelState.IsValid)
            {
                estadoClinico.Id = Guid.NewGuid();
                _context.Add(estadoClinico);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(estadoClinico);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var estadoClinico = await _context.EstadoClinico.FindAsync(id);

            if (estadoClinico == null)
                return NotFound();

            return View(estadoClinico);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EstadoClinico estadoClinico)
        {
            if (id != estadoClinico.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                try {
                    _context.Update(estadoClinico);
                    await _context.SaveChangesAsync();
                } catch(DbUpdateConcurrencyException)
                {
                    if (!EstadoClinicoExists(estadoClinico.Id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estadoClinico);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var estadoClinico = await _context.EstadoClinico.FirstOrDefaultAsync(x => x.Id == id);

            if (estadoClinico == null)
            {
                return NotFound();
            }
            else
            {
                return View(estadoClinico);
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estadoClinico = await _context.EstadoClinico.FindAsync(id);

            try {
                _context.EstadoClinico.Remove(estadoClinico);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return RedirectToAction(nameof(Index));
        }

        private bool EstadoClinicoExists(Guid id)
        {
            return _context.EstadoClinico.Any(x => x.Id == id);
        }
    }
}
