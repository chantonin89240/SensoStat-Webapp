namespace SensoStat.WebApplication.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class SessionViewModel
    {
        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string? AccueilMsg { get; set; }
        public List<InstructionItemViewModel>? Instructions { get; set; }
        // public List<string>? Questions { get; set; }

        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string? FinallMsg { get; set; }

        public SessionViewModel()
        {
            Instructions = new List<InstructionItemViewModel>();
        }
    }
}