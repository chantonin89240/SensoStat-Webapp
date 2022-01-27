namespace SensoStat.WebApplication.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class PresentationViewModel
    {
        [Required]
        public int IdPanelist { get; set; }

        [Required]
        public int IdProduct { get; set; }

        [Required]
        public int Rank { get; set; }

        public FileUpload? FileUpload { get; set; }
    }
}