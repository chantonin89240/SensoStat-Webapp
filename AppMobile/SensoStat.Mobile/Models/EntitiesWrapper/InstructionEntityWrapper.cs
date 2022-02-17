using System;
using SensoStat.Mobile.Models.Entities.Interfaces;

namespace SensoStat.Mobile.Models.EntitiesWrapper
{
    public class InstructionEntityWrapper : IInstructionEntity, IProductEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }

        public string IdProduct { get ; set ; }
        public string Code { get ; set ; }

        public string FormatText => $"{Content} {Code}";

        public string GetPosition()
        {
            return Position.ToString();
        }

        public string DynamicFormatText { get => $"{Content} {Code}"; }


        public InstructionEntityWrapper()
        {
        }

        public InstructionEntityWrapper(IInstructionEntity instruction, IProductEntity product) : this()
        {
            Id = instruction.Id;
            Content = instruction.Content;
            Position = instruction.Position;

            IdProduct = product.IdProduct;
            Code = product.Code;
        }
    }
}
