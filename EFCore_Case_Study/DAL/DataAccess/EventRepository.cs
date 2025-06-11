// EventRepository.cs
using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.DataAccess
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

        public EventRepository(EventDbContext context)
        {
            _context = context;
        }

        public void AddEvent(EventDetails eventDetails)
        {
            _context.Events.Add(eventDetails);
            _context.SaveChanges();
        }

        public List<EventDetails> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public EventDetails GetEventById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == id);
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _context.Sessions.Where(s => s.EventId == eventId).ToList();
        }

        public void RemoveEvent(int id)
        {
            var eventDetails = _context.Events.FirstOrDefault(e => e.EventId == id);
            if (eventDetails != null)
            {
                _context.Events.Remove(eventDetails);
                _context.SaveChanges();
            }
        }

        public void UpdateEvent(EventDetails eventDetails)
        {
            var existingEvent = _context.Events.FirstOrDefault(e => e.EventId == eventDetails.EventId);
            if (existingEvent != null)
            {
                existingEvent.EventName = eventDetails.EventName;
                existingEvent.EventCategory = eventDetails.EventCategory;
                existingEvent.EventDate = eventDetails.EventDate;
                existingEvent.Description = eventDetails.Description;
                existingEvent.Status = eventDetails.Status;
                _context.SaveChanges();
            }
        }
    }
}