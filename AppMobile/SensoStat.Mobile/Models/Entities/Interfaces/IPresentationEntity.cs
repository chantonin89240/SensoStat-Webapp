using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IPresentationEntity
    {
        int Rank { get; set; }

        int IdPanelist { get; set; }

        int IdProduct { get; set; }
    }
}
