namespace SensoStat.Entities.Request
{
    public class ProductRequest
    {
        public string CodeProduct { get; set; }

        public int IdSession { get; set; }

        public List<Response> Responses { get; set; }

        public List<Presentation> Presentations { get; set; }

    }
}
