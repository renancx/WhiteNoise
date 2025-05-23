using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WhiteNoise.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Apelido { get; set; }

        [PersonalData]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [PersonalData]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
