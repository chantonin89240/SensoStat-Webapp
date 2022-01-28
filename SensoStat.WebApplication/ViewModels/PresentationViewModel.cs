namespace SensoStat.WebApplication.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class PresentationViewModel
    {
        [Required]
        public string IdPanelist { get; set; }

        [Required]
        public int IdProduct1 { get; set; }

        [Required]
        public int IdProduct2 { get; set; }
        [Required]
        public int IdProduct3 { get; set; }
        // [Required]
        // public int Rank { get; set; }

    }
}