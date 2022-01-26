namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Panelist
    {
        public int Id { get; set; }

        [Required]
        public string CodePanelist { get; set; }

        public List<Publication> Publications { get; set; }

        public List<Response> Responses { get; set; }

        public List<Presentation> Presentations { get; set; }

        public Panelist()
        {
            this.Publications = new List<Publication>();
            this.Responses = new List<Response>();
            this.Presentations = new List<Presentation>();
        }

        public Panelist(int id, string codePanelist) : this()
        {
            this.Id = id;
            this.CodePanelist = codePanelist;
        }
    }
}
