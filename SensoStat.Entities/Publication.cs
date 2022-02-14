namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Publication
    {
        public Session Session { get; set; }

        public int IdSession { get; set; }

        public Panelist Panelist { get; set; }

        public int IdPaneslist { get; set; }

        [Required]
        public string? Url { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public Publication() { }

        public Publication(Session session, Panelist panelist, string url, DateTime dateStart, DateTime dateEnd)
        {
            this.Url = url;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.Session = session;
            this.IdSession = session.Id;
            this.Panelist = panelist;
            this.IdPaneslist = panelist.Id;
        }

    }
}
