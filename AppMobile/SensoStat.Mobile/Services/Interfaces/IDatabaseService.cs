using System;
using System.Collections.Generic;
using SensoStat.Mobile.Models.Entities;

namespace SensoStat.Mobile.Services.Interfaces
{
    public interface IDatabaseService
    {
        SessionEntity InsertSession(SessionEntity Session);

        SessionEntity GetSessionById(int id);

        void DeleteSession(SessionEntity Session);

        List<SessionEntity> GetSessions();
    }
}
