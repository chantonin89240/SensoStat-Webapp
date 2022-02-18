namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Session
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MsgAccueil { get; set; }

        public string MsgFinal { get; set; }

        public string Etat { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateUpdate { get; set; }

        public DateTime? DateClose { get; set; }

        public User Person { get; set; }

        public int IdPerson { get; set; }

        public List<Product> Products { get; set; }

        public List<Instruction> Instructions { get; set; }

        public List<Publication> Publications { get; set; }

        public Session()
        {
            this.Products = new List<Product>();
            this.Instructions = new List<Instruction>();
            this.Publications = new List<Publication>();
        }

        public Session(string name, string msgAccueil, string msgFinal, string etat, DateTime dateCreate, DateTime dateUpdate, DateTime dateClose, User person) : this()
        {
            this.Name = name;
            this.MsgAccueil = msgAccueil;
            this.MsgFinal = msgFinal;
            this.Etat = etat;
            this.DateCreate = dateCreate;
            this.DateUpdate = dateUpdate;
            this.DateClose = dateClose;
            this.Person = person;
            this.IdPerson = person.Id;
        }
    }
}