namespace SensoStat.WebApplication.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class SessionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez saisir le nom de la séance")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Veuillez saisir le message d'accueil de la séance")]
        public string MsgAccueil { get; set; }
        [Required(ErrorMessage = "Veuillez saisir le message final de la séance")]
        public string MsgFinal { get; set; }
        public List<string>? Types { get; set; }
        public List<string> Messages { get; set; }
        public string? Etat { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public UserViewModel? Person { get; set; }
        public int? IdPerson { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<PresentationViewModel>? Presentations { get; set; }
        [UIHint("InstructionItemViewModel")]
        public List<InstructionItemViewModel> Instructions { get; set; }
        //public List<PublicationViewModel> Publications { get; set; }
        public SessionViewModel()
        {
            this.Products = new List<ProductViewModel>();
            this.Instructions = new List<InstructionItemViewModel>();
            this.Presentations = new List<PresentationViewModel>();
        }
        public SessionViewModel(string name, string etat, UserViewModel person) : this()
        {
            this.Name = name;
            this.Etat = etat;
            this.Person = person;
            this.IdPerson = person.Id;
        }
    }
}