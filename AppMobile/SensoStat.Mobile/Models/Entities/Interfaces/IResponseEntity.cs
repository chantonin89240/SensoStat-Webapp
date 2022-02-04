using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IResponseEntity
    {
        int Id { get; set; }

        string IdResponse { get; set; }

        string Content { get; set; }

        string IdInstruction { get; set; }
    }
}
