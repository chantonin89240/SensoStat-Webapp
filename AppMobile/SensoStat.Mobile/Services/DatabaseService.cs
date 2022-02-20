using System;
using System.Collections.Generic;
using SensoStat.Mobile.Models.Entities;
using SensoStat.Mobile.Repositories.Interface;
using SensoStat.Mobile.Services.Interfaces;

namespace SensoStat.Mobile.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IRepository<SessionEntity> _sessionRepository;

        public DatabaseService(IRepository<SessionEntity> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        #region Session

        public SessionEntity InsertSession(SessionEntity session)
        {
            try
            {
                return _sessionRepository.Insert(session);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public SessionEntity GetSessionById(int id)
        {
            try
            {
                return _sessionRepository.GetById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void DeleteSession(SessionEntity session)
        {
            try
            {
                _sessionRepository.Delete(session);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<SessionEntity> GetSessions()
        {
            try
            {
                return _sessionRepository.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion
    }
}
