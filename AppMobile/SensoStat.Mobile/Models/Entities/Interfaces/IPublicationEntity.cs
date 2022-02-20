using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IPublicationEntity
    {
        string Url { get; set; }

        DateTime DateStart { get; set; }

        DateTime DateEnd { get; set; }
    }
}
