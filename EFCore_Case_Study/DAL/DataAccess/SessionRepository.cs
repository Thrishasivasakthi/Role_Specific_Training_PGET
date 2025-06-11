// SessionRepository.cs
using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.DataAccess
{
    public class SessionRepository : ISessionRepository
    {
        private readonly EventDbContext _context;

        public SessionRepository(EventDbContext context)
        {
            _context = context;
        }

        public void AddSession(SessionInfo session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public List<SessionInfo> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }

        public SessionInfo GetSessionById(int id)
        {
            return _context.Sessions.FirstOrDefault(s => s.SessionId == id);
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _context.Sessions.Where(s => s.EventId == eventId).ToList();
        }

        public void RemoveSession(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.SessionId == id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                _context.SaveChanges();
            }
        }

        public void UpdateSession(SessionInfo session)
        {
            var existingSession = _context.Sessions.FirstOrDefault(s => s.SessionId == session.SessionId);
            if (existingSession != null)
            {
                existingSession.EventId = session.EventId;
                existingSession.SessionTitle = session.SessionTitle;
                
                existingSession.Description = session.Description;
                existingSession.SessionStart = session.SessionStart;
                existingSession.SessionEnd = session.SessionEnd;
                existingSession.SessionUrl = session.SessionUrl;
                _context.SaveChanges();
            }
        }
    }
}