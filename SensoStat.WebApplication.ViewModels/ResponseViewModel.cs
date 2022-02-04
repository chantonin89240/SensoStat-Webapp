using System;
using System.ComponentModel.DataAnnotations;

namespace SensoStat.WebApplication.ViewModels
{
    public class ResponseViewModel
    {
        [Required]
        public string CommentResponse { get; set; }

        public DateTime DateResponse { get; set; }

        public InstructionItemViewModel Instruction { get; set; }

        public int IdInstruction { get; set; }

        public ProductViewModel Product { get; set; }

        public int IdProduct { get; set; }

        public PanelistViewModel Panelist { get; set; }

        public int IdPanelist { get; set; }

        public ResponseViewModel() { }

        public ResponseViewModel(PanelistViewModel panelist, ProductViewModel product, InstructionItemViewModel intruction, string commentResponse, DateTime dateResponse)
        {
            this.CommentResponse = commentResponse;
            this.DateResponse = dateResponse;
            this.Instruction = intruction;
            this.IdInstruction = intruction.Id;
            this.Product = product;
            this.IdProduct = product.Id;
            this.Panelist = panelist;
            this.IdPanelist = panelist.Id;
        }
    }
}

