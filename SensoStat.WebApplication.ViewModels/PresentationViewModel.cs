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

        public PresentationViewModel() { }

        public PresentationViewModel(PanelistViewModel panelist, ProductViewModel product, int rank) : this()
        {
            this.Rank = rank;
            this.Panelist = panelist;
            this.IdPanelist = panelist.Id;
            this.Product = product;
            this.IdProduct = product.Id;
        }
    }
}