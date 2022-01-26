namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Panelist
    {
        public int Id { get; set; }

        [Required]
        public string CodePanelist { get; set; }

        public List<Publication> Publication { get; set; }

        public List<Response> Response { get; set; }

        public List<Presentation> Presentation { get; set; }

        public Panelist()
        {
            this.Publication = new List<Publication>();
            this.Response = new List<Response>();
            this.Presentation = new List<Presentation>();
        }

        public Panelist(int id, string codePanelist) : this()
        {
            this.Id = id;
            this.CodePanelist = codePanelist;
        }
    }
}
