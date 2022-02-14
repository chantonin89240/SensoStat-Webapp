namespace SensoStat.WebApplication.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class SessionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string MsgAccueil { get; set; }

        [Required(ErrorMessage = "Veuillez saisir ce champ")]
        public string MsgFinal { get; set; }

        public string Etat { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }

        public DateTime? DateClose { get; set; }

        public UserViewModel Person { get; set; }

        public int IdPerson { get; set; }

        public List<ProductViewModel> Products { get; set; }

        [UIHint("InstructionItemViewModel")]
        public List<InstructionItemViewModel> Instructions { get; set; }

        public List<PublicationViewModel> Publications { get; set; }

        public SessionViewModel()
        {
            this.Products = new List<ProductViewModel>();
            this.Instructions = new List<InstructionItemViewModel>();
            this.Publications = new List<PublicationViewModel>();
        }

        public SessionViewModel(string name, string etat, DateTime dateCreate, DateTime dateUpdate, DateTime dateClose, UserViewModel person) : this()
        {
            this.Name = name;
            this.Etat = etat;
            this.DateCreate = dateCreate;
            this.DateUpdate = dateUpdate;
            this.DateClose = dateClose;
            this.Person = person;
            this.IdPerson = person.Id;
        }

    }
}