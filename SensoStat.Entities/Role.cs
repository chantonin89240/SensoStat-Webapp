namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        public List<Person> Persons { get; set; }

        public Role()
        {
            this.Persons = new List<Person>();
        }

        public Role(int id, string libelle) : this()
        {
            this.Id = id;
            this.Libelle = libelle;
        }
    }
}
