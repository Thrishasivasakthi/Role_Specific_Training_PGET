using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface ISessionRepository
    {
        void AddSession(SessionInfo session);
        void RemoveSession(int id);
        void UpdateSession(SessionInfo session);
        SessionInfo GetSessionById(int id);
        List<SessionInfo> GetAllSessions();
        List<SessionInfo> GetSessionsByEventId(int eventId);
    }
}
