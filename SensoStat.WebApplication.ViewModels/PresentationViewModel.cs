using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class PresentationViewModel
    {
        public int IdPanelist { get; set; }

        public PanelistViewModel Panelist { get; set; }

        public int IdProduct { get; set; }

        public ProductViewModel Product { get; set; }

        public int Rank { get; set; }

        public int IdSession { get; set; }

        public PresentationViewModel() { }

        public PresentationViewModel(PanelistViewModel panelist, ProductViewModel product, int rank, int idSession) : this()
        {
            this.Rank = rank;
            this.Panelist = panelist;
            this.IdPanelist = panelist.Id;
            this.Product = product;
            this.IdProduct = product.Id;
            this.IdSession = idSession;
        }
    }
}