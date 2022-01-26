namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Session
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Etat { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }

        public DateTime DateClose { get; set; }

        public Person Person { get; set; }

        public List<Product> Product { get; set; }

        public List<Instruction> Instruction { get; set; }

        public List<Publication> Publication { get; set; }


        public Session()
        {
            this.Product = new List<Product>();
            this.Instruction = new List<Instruction>();
            this.Publication = new List<Publication>();
        }

        public Session(int id, string name, string etat, DateTime dateCreate, DateTime dateUpdate, DateTime dateClose, Person person) : this()
        {
            this.Id = id;
            this.Name = name;
            this.Etat = etat;
            this.DateCreate = dateCreate;
            this.DateUpdate = dateUpdate;
            this.DateClose = dateClose;
            this.Person = person;
        }
    }
}