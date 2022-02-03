using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IResponseEntity
    {
        string Id { get; set; }

        string Content { get; set; }

        string IdInstruction { get; set; }
    }
}
