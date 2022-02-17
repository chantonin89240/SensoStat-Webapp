using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class PresentationViewModel
    {
        public string CodePanelist { get; set; }

        public PanelistViewModel Panelist { get; set; }

        public string CodeProduct { get; set; }

        public ProductViewModel Product { get; set; }

        public int Rank { get; set; }

        public int IdSession { get; set; }

        public PresentationViewModel() { }

        public PresentationViewModel(string codePanelist, string codeProduct, int rank, int idSession) : this()
        {
            this.Rank = rank;
            this.CodePanelist = codePanelist;
            this.CodeProduct = codeProduct;
            this.IdSession = idSession;
        }
    }
}