using System;
using SensoStat.Mobile.Models.Entities.Interfaces;

namespace SensoStat.Mobile.Models.Entities
{
    public class PublicationEntity : IPublicationEntity
    {
        public string Url { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public PublicationEntity()
        {
        }
    }
}
