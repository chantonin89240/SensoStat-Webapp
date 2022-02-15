namespace SensoStat.Models.HttpRequest
{
    using SensoStat.Entities;

    public class ProductRequest
    {
        public string CodeProduct { get; set; }

        public int IdSession { get; set; }

        public List<Response> Responses { get; set; }

        public List<Presentation> Presentations { get; set; }

    }
}
