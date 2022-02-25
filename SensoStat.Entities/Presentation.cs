namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Presentation
    {
        public int Rank { get; set; }

        public Panelist Panelist { get; set; }

        public int IdPanelist { get; set; }

        public Product Product { get; set; }

        public int IdProduct { get; set; }

        public Presentation() { }

        public Presentation(int idPanelist, int idProduct, int rank) : this()
        {
            this.Rank = rank;
            this.IdPanelist = idPanelist;
            this.IdProduct = idProduct;
        }
    }
}
