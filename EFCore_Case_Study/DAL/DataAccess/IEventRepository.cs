using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IEventRepository
    {
        void AddEvent(EventDetails eventDetails);
        void RemoveEvent(int id);
        void UpdateEvent(EventDetails eventDetails);
        EventDetails GetEventById(int id);
        List<EventDetails> GetAllEvents();
        List<SessionInfo> GetSessionsByEventId(int eventId);
    }
}
