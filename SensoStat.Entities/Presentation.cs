namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Presentation
    {
        [Required]
        public int Rank { get; set; }

        public Panelist Panelist { get; set; }

        // [ForeignKey(nameof(Panelist))]
        public int IdPanelist { get; set; }

        public Product Product { get; set; }

        // [ForeignKey(nameof(Product))]
        public int IdProduct { get; set; }

        public int IdSession { get; set; }

        public Presentation() { }

        public Presentation(Panelist panelist, Product product, int rank, int idSession) : this()
        {
            this.Rank = rank;
            this.Panelist = panelist;
            this.IdPanelist = panelist.Id;
            this.Product = product;
            this.IdProduct = product.Id;
            this.IdSession = idSession;
        }
    }
}
