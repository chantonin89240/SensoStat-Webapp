using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IInstructionEntity
    {
        int Id { get; set; }

        string Content { get; set; }

        int Position { get; set; }
    }
}
