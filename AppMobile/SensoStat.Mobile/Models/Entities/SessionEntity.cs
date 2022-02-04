using System.Collections.Generic;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class SessionEntity : ISessionEntity
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string IdSession { get; set; }

        public string Name { get; set; }

        public string MsgHome { get; set; }

        public string MsgFinal { get; set; }

        public List<InstructionEntity> Instructions { get; set; }

        public List<ProductEntity> ProductRanked { get; set; }

        public SessionEntity()
        {
            Instructions = new List<InstructionEntity>();
            ProductRanked = new List<ProductEntity>();
        }

        public SessionEntity(SessionDownDto session) :this()
        {
            IdSession = session.Id;
            Name = session.Name;
            MsgHome = session.MsgHome;
            MsgFinal = session.MsgFinal;
        }
    }
}
