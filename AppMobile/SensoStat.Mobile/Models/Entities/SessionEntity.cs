using System.Collections.Generic;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class SessionEntity : ISessionEntity
    {
        [PrimaryKey] public int Id { get; set; }

        public string Name { get; set; }

        public string MsgHome { get; set; }

        public string MsgFinal { get; set; }

        //public PublicationEntity Publication { get; set; }

        //public List<InstructionEntity> Instructions { get; set; }

        //public List<ProductEntity> Products { get; set; }

        //public List<PresentationEntity> Presentations { get; set; }

        public SessionEntity()
        {
            //Instructions = new List<InstructionEntity>();
            //Products = new List<ProductEntity>();
            //Presentations = new List<PresentationEntity>();
        }

        public SessionEntity(SessionDownDto session) :this()
        {
            Id = session.Id;
            Name = session.Name;
            MsgHome = session.MsgHome;
            MsgFinal = session.MsgFinal;
        }
    }
}
