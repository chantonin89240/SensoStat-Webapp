using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class AuthentificationViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

