using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class InstructionItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        [Required]
        public int Chronology { get; set; }

        public int IsQuestion { get; set; }

        public SessionViewModel Session { get; set; }

        public int IdSession { get; set; }

        public List<ResponseViewModel> Responses { get; set; }

        public InstructionItemViewModel()
        {
            this.Libelle = "";
        }

        public InstructionItemViewModel(string libelle, int chronology, int isQuestion, SessionViewModel session)
        {
            this.Libelle = libelle;
            this.Chronology = chronology;
            this.IsQuestion = isQuestion;
            this.Session = session;
            this.IdSession = session.Id;
        }
    }
}

