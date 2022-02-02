using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public class IInstructionEntity
    {
        string Id { get; set; }

        string Content { get; set; }

        int Position { get; set; }
    }
}
