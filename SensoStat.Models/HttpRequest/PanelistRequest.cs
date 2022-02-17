namespace SensoStat.Models.HttpRequest
{
    using SensoStat.Entities;

    public class PanelistRequest
    {
        public string CodePanelist { get; set; }

        public List<Publication> Publications { get; set; }

        public List<Response> Responses { get; set; }

        public List<Presentation> Presentations { get; set; }
    }
}
