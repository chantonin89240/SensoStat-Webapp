using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class SessionVM
    {
        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string MsgAccueil { get; set; }

        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string MsgFinal { get; set; }

        public List<string> Types { get; set; }

        public List<string> Messages { get; set; }

 

    }
}

