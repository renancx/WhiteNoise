using Microsoft.AspNetCore.Mvc;

namespace WhiteNoise.Controllers
{
    public class PacienteController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Mensagem = "Teste";
            return View();
        }

        [HttpGet]
        public IActionResult ConsultarPaciente(string id)
        {
            return View();
        }
    }
}
