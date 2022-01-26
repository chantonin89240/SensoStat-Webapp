namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Presentation
    {
        [Required]
        public int Rank { get; set; }

        public List<Panelist> Panelists { get; set; }

        public List<Product> Products { get; set; }

        public Presentation()
        {
            this.Panelists = new List<Panelist>();
            this.Products = new List<Product>();
        }

        public Presentation(int rank) : this()
        {
            this.Rank = rank;
        }
    }
}
