using System;
using System.Collections.Generic;
using System.Linq;
using WhiteNoise.Models.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace WhiteNoise.Controllers
{
    public class PacienteController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var pacientes = ObterPacientes();

            return View(pacientes);
        }

        [HttpGet]
        public IActionResult ConsultarPaciente(string id)
        {
            var paciente = ObterPaciente(id);

            if (paciente == null)
                return NotFound();

            return View(paciente);
        }

        [HttpPost]
        public IActionResult CadastrarPaciente()
        {
            return View();
        }

        private Paciente ObterPaciente(string id)
        {
            var pacientes = ObterPacientes();

            if (pacientes != null && id != string.Empty)
            {
                var paciente = pacientes.FirstOrDefault(x => x.Nome == id);

                return paciente;
            }

            return null;
        }

        private List<Paciente> ObterPacientes()
        {
            //Método temporário que está criando novos obj do tipo Paciente para exibir na view
            var pacientes = new List<Paciente>()
            {
                new Paciente
                {
                    Nome = "Renan",
                    Cpf = "12345678900",
                    Telefones = new List<Telefone>()
                    {
                        new Telefone() { Id = Guid.NewGuid(), Tipo = "Celular", Numero = "89923212456" },
                        new Telefone() { Id = Guid.NewGuid(), Tipo = "Residencial", Numero = "82342312336" }
                    }
                },
                new Paciente
                {
                    Nome = "Paciente",
                    Cpf = "00987654321",
                    Telefones = new List<Telefone>()
                    {
                        new Telefone() { Id = Guid.NewGuid(), Tipo = "Celular", Numero = "1234561234" },
                        new Telefone() { Id = Guid.NewGuid(), Tipo = "Residencial", Numero = "8978978978" }
                    }
                },
                new Paciente
                {
                    Nome = "Paciente 2",
                    Cpf = "00982654321",
                    Telefones = new List<Telefone>()
                    {
                        new Telefone() { Id = Guid.NewGuid(), Tipo = "Celular", Numero = "1234234234" }
                    }
                }
            };

            return pacientes;
        }

    }
}
