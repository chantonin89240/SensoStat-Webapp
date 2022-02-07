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

        [UIHint("InstructionItemViewModel")]
        public List<InstructionItemViewModel> Instructions { get; set; }

        public SessionVM()
        {
            this.Instructions = new List<InstructionItemViewModel>();
        }

    }
}

