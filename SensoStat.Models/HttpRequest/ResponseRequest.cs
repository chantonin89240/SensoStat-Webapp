namespace SensoStat.Models.HttpRequest
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ResponseRequest
    {
        [Required]
        public int IdInstruction { get; set; }

        [Required]
        public int IdProduct { get; set; }

        [Required]
        public int IdPanelist { get; set; }

        [Required]
        public string? CommentResponse { get; set; }

    }
}

