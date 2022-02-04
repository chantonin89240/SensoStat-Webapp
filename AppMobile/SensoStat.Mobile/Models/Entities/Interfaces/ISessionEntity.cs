using System;
using System.Collections.Generic;

namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface ISessionEntity
    {
        int Id { get; set; }

        string Name { get; set; }

        string MsgHome { get; set; }

        string MsgFinal { get; set; }

        List<InstructionEntity> Instructions { get; set; }

        List<ProductEntity> ProductRanked { get; set; }
    }
}
