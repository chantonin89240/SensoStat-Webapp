namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Presentation
    {
        [Required]
        public int Rank { get; set; }

        [ForeignKey(nameof(IdPanelist))]
        public Panelist Panelist { get; set; }

        public int IdPanelist { get; set; }

        [ForeignKey(nameof(IdProduct))]
        public Product Product { get; set; }

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
