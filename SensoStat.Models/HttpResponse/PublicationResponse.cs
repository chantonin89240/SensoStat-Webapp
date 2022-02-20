namespace SensoStat.Models.HttpResponse
{
    using SensoStat.Entities;

    public class PublicationResponse
    {
        public int IdSession { get; set; }

        public int IdPaneslist { get; set; }

        public string? Url { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public PublicationResponse(Publication publication)
        {
            this.IdSession = publication.IdSession;
            this.IdPaneslist = publication.IdPaneslist;
            this.Url = publication.Url;
            this.DateStart = publication.DateStart;
            this.DateEnd = publication.DateEnd;
        }
    }
}

