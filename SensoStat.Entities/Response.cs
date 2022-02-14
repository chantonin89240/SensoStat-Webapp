namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Response
    {
        public Instruction Instruction { get; set; }

        public int IdInstruction { get; set; }

        public Product Product { get; set; }

        public int IdProduct { get; set; }

        public Panelist Panelist { get; set; }

        public int IdPanelist { get; set; }

        [Required]
        public string CommentResponse { get; set; }

        public DateTime DateResponse { get; set; }

        public Response() { }

        public Response(Panelist panelist, Product product, Instruction intruction, string commentResponse, DateTime dateResponse)
        {
            this.CommentResponse = commentResponse;
            this.DateResponse = dateResponse;
            this.Instruction = intruction;
            this.IdInstruction = intruction.Id;
            this.Product = product;
            this.IdProduct = product.Id;
            this.Panelist = panelist;
            this.IdPanelist = panelist.Id;
        }
    }
}
