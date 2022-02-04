using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        public List<UserViewModel> Persons { get; set; }

        public RoleViewModel()
        {
            this.Persons = new List<UserViewModel>();
        }

        public RoleViewModel(string libelle) : this()
        {
            this.Libelle = libelle;
        }
    }
}

