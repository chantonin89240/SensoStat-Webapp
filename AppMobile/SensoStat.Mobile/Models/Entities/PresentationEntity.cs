using System;
using SensoStat.Mobile.Models.Entities.Interfaces;

namespace SensoStat.Mobile.Models.Entities
{
    public class PresentationEntity : IPresentationEntity
    {
        public int Rank { get; set; }

        public int IdPanelist { get; set; }

        public int IdProduct { get; set; }

        public PresentationEntity()
        {
        }
    }
}
