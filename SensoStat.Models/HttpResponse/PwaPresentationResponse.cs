namespace SensoStat.Models.HttpResponse
{
    using SensoStat.Entities;

    public class PwaPresentationResponse
    {
        public int Rank { get; set; }

        public int IdPanelist { get; set; }

        public int IdProduct { get; set; }

        public string CodeProduit { get; set; }

        public PwaPresentationResponse(Presentation presentation)
        {
            Rank = presentation.Rank;
            IdPanelist = presentation.IdPanelist;
            IdProduct = presentation.IdProduct;
        }

        public PwaPresentationResponse()
        {
        }
    }
}

