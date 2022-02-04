using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string CodeProduct { get; set; }

        public SessionViewModel Session { get; set; }

        public int IdSession { get; set; }

        public List<ResponseViewModel> Responses { get; set; }

        public List<PresentationViewModel> Presentations { get; set; }

        public ProductViewModel()
        {
            this.Responses = new List<ResponseViewModel>();
            this.Presentations = new List<PresentationViewModel>();
        }

        public ProductViewModel(string codeProduct, SessionViewModel session) : this()
        {
            this.CodeProduct = codeProduct;
            this.Session = session;
            this.IdSession = session.Id;
        }
    }
}

