namespace SensoStat.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Publication
    {
        public Session Session { get; set; }

        public int IdSession { get; set; }

        public Panelist Panelist { get; set; }

        public int IdPaneslist { get; set; }

        public string? Url { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public string Salt { get; set; }

        public Publication() { }

        public Publication(Session session, Panelist panelist, string url, DateTime dateStart, DateTime dateEnd, string salt)
        {
            this.Url = url;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.IdSession = session.Id;
            this.IdPaneslist = panelist.Id;
            this.Salt = salt;
        }

    }
}
