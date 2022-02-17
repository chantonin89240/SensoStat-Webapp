namespace SensoStat.Models.HttpResponse
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using SensoStat.Entities;

    public class PresentationResponse
    {
        public int Rank { get; set; }

        public string CodePanelist { get; set; }

        public string CodeProduct { get; set; }

        public PresentationResponse(Presentation presentation)
        {
            Rank = presentation.Rank;
            CodePanelist = presentation.Panelist.CodePanelist;
            CodeProduct = presentation.Product.CodeProduct;
        }
    }
}

