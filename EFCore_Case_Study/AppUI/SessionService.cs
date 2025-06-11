// SessionService.cs
using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace AppUI
{
    public class SessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public void AddSession(SessionInfo session)
        {
            _sessionRepository.AddSession(session);
        }

        public void UpdateSession(SessionInfo session)
        {
            _sessionRepository.UpdateSession(session);
        }

        public void DeleteSession(int sessionId)
        {
            _sessionRepository.RemoveSession(sessionId);
        }

        public SessionInfo GetSessionById(int sessionId)
        {
            return _sessionRepository.GetSessionById(sessionId);
        }

        public List<SessionInfo> GetAllSessions()
        {
            return _sessionRepository.GetAllSessions();
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _sessionRepository.GetSessionsByEventId(eventId);
        }
    }
}