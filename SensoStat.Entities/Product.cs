namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public  class Product
    {
        public int Id { get; set; }

        [Required]
        public string CodeProduct { get; set; }

        public Session Session { get; set; }

        public int IdSession { get; set; }

        public List<Response> Responses { get; set; }

        public List<Presentation> Presentations { get; set; }

        public Product()
        {
            this.Responses = new List<Response>();
            this.Presentations = new List<Presentation>();
        }

        public Product(string codeProduct, Session session) : this()
        {
            this.CodeProduct = codeProduct;
            this.Session = session;
            this.IdSession = session.Id;
        }
    }
}
