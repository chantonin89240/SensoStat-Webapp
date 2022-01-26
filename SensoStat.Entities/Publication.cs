namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Publication
    {
        [Required]
        public string Url { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public Session Session { get; set; }

        public int IdSession { get; set; }

        public Panelist Panelist { get; set; }

        public int IdPaneslist { get; set; }

        public Publication() { }

        public Publication(string url, DateTime dateStart, DateTime dateEnd, Session session, Panelist panelist)
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
