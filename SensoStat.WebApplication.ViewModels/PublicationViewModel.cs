using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class PublicationViewModel
    {
        [Required]
        public string? Url { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public SessionViewModel Session { get; set; }

        public int IdSession { get; set; }

        public PanelistViewModel Panelist { get; set; }

        public int IdPaneslist { get; set; }

        public PublicationViewModel() { }

        public PublicationViewModel(SessionViewModel session, PanelistViewModel panelist, string url, DateTime dateStart, DateTime dateEnd)
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

