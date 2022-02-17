namespace SensoStat.Models.HttpRequest
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PresentationRequest
    {
        [Required]
        public int Rank { get; set; }

        [Required]
        public string CodePanelist { get; set; }

        [Required]
        public string CodeProduct { get; set; }

        [Required]
        public int IdSession { get; set; }
    }
}

