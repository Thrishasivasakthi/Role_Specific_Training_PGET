using AppUI;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Setup DbContext
        var options = new DbContextOptionsBuilder<EventDbContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EventDb;Trusted_Connection=True;")
            .Options;

        // Create repositories
        var dbContext = new EventDbContext(options);
        var userRepo = new UserRepository(dbContext);
        var eventRepo = new EventRepository(dbContext);
        var sessionRepo = new SessionRepository(dbContext);

        // Create services
        var userService = new UserService(userRepo);
        var eventService = new EventService(eventRepo);
        var sessionService = new SessionService(sessionRepo);

        // Main menu loop
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Event Management System ===");
            Console.WriteLine("1. User Management");
            Console.WriteLine("2. Event Management");
            Console.WriteLine("3. Session Management");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    UserManagementMenu(userService);
                    break;
                case "2":
                    EventManagementMenu(eventService, sessionService);
                    break;
                case "3":
                    SessionManagementMenu(sessionService);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void UserManagementMenu(UserService userService)
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== User Management ===");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Find User by Email");
            Console.WriteLine("4. Update User");
            Console.WriteLine("5. Delete User");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddUser(userService);
                    break;
                case "2":
                    ViewAllUsers(userService);
                    break;
                case "3":
                    FindUserByEmail(userService);
                    break;
                case "4":
                    UpdateUser(userService);
                    break;
                case "5":
                    DeleteUser(userService);
                    break;
                case "6":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void EventManagementMenu(EventService eventService, SessionService sessionService)
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== Event Management ===");
            Console.WriteLine("1. Add Event");
            Console.WriteLine("2. View All Events");
            Console.WriteLine("3. View Event Details");
            Console.WriteLine("4. Update Event");
            Console.WriteLine("5. Delete Event");
            Console.WriteLine("6. View Sessions for Event");
            Console.WriteLine("7. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEvent(eventService);
                    break;
                case "2":
                    ViewAllEvents(eventService);
                    break;
                case "3":
                    ViewEventDetails(eventService);
                    break;
                case "4":
                    UpdateEvent(eventService);
                    break;
                case "5":
                    DeleteEvent(eventService);
                    break;
                case "6":
                    ViewEventSessions(eventService, sessionService);
                    break;
                case "7":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void SessionManagementMenu(SessionService sessionService)
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== Session Management ===");
            Console.WriteLine("1. Add Session");
            Console.WriteLine("2. View All Sessions");
            Console.WriteLine("3. View Session Details");
            Console.WriteLine("4. Update Session");
            Console.WriteLine("5. Delete Session");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddSession(sessionService);
                    break;
                case "2":
                    ViewAllSessions(sessionService);
                    break;
                case "3":
                    ViewSessionDetails(sessionService);
                    break;
                case "4":
                    UpdateSession(sessionService);
                    break;
                case "5":
                    DeleteSession(sessionService);
                    break;
                case "6":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    #region User CRUD Operations
    static void AddUser(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("=== Add New User ===");

        var user = new UserInfo();

        Console.Write("Email: ");
        user.EmailId = Console.ReadLine();

        Console.Write("Username: ");
        user.UserName = Console.ReadLine();

        Console.Write("Role (Admin/Participant): ");
        user.Role = Console.ReadLine();

        Console.Write("Password: ");
        user.Password = Console.ReadLine();

        try
        {
            userService.AddUser(user);
            Console.WriteLine("\nUser added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ViewAllUsers(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("=== All Users ===");

        var users = userService.GetAllUsers();

        if (users.Count == 0)
        {
            Console.WriteLine("No users found!");
        }
        else
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Email: {user.EmailId}, Name: {user.UserName}, Role: {user.Role}");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void FindUserByEmail(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("=== Find User by Email ===");

        Console.Write("Enter user email: ");
        var email = Console.ReadLine();

        var user = userService.GetUserByEmail(email);

        if (user == null)
        {
            Console.WriteLine("\nUser not found!");
        }
        else
        {
            Console.WriteLine("\nUser Details:");
            Console.WriteLine($"Email: {user.EmailId}");
            Console.WriteLine($"Name: {user.UserName}");
            Console.WriteLine($"Role: {user.Role}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateUser(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("=== Update User ===");

        Console.Write("Enter user email to update: ");
        var email = Console.ReadLine();

        var user = userService.GetUserByEmail(email);

        if (user == null)
        {
            Console.WriteLine("\nUser not found!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nLeave blank to keep current value");
        Console.Write($"New Username ({user.UserName}): ");
        var username = Console.ReadLine();
        if (!string.IsNullOrEmpty(username)) user.UserName = username;

        Console.Write($"New Role ({user.Role}): ");
        var role = Console.ReadLine();
        if (!string.IsNullOrEmpty(role)) user.Role = role;

        Console.Write("New Password: ");
        var password = Console.ReadLine();
        if (!string.IsNullOrEmpty(password)) user.Password = password;

        try
        {
            userService.UpdateUser(user);
            Console.WriteLine("\nUser updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void DeleteUser(UserService userService)
    {
        Console.Clear();
        Console.WriteLine("=== Delete User ===");

        Console.Write("Enter user email to delete: ");
        var email = Console.ReadLine();

        try
        {
            userService.DeleteUser(email);
            Console.WriteLine("\nUser deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    #endregion

    #region Event CRUD Operations
    static void AddEvent(EventService eventService)
    {
        Console.Clear();
        Console.WriteLine("=== Add New Event ===");

        var eventDetails = new EventDetails();

        Console.Write("Event Name: ");
        eventDetails.EventName = Console.ReadLine();

        Console.Write("Event Category: ");
        eventDetails.EventCategory = Console.ReadLine();

        Console.Write("Event Date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out var date))
        {
            eventDetails.EventDate = date;
        }

        Console.Write("Description (optional): ");
        eventDetails.Description = Console.ReadLine();

        Console.Write("Status (Active/In-Active): ");
        eventDetails.Status = Console.ReadLine();

        try
        {
            eventService.AddEvent(eventDetails);
            Console.WriteLine("\nEvent added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ViewAllEvents(EventService eventService)
    {
        Console.Clear();
        Console.WriteLine("=== All Events ===");

        var events = eventService.GetAllEvents();

        if (events.Count == 0)
        {
            Console.WriteLine("No events found!");
        }
        else
        {
            foreach (var ev in events)
            {
                Console.WriteLine($"ID: {ev.EventId}, Name: {ev.EventName}, Date: {ev.EventDate:yyyy-MM-dd}, Status: {ev.Status}");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ViewEventDetails(EventService eventService)
    {
        Console.Clear();
        Console.WriteLine("=== Event Details ===");

        Console.Write("Enter Event ID: ");
        if (!int.TryParse(Console.ReadLine(), out var eventId))
        {
            Console.WriteLine("\nInvalid Event ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        var eventDetails = eventService.GetEventById(eventId);

        if (eventDetails == null)
        {
            Console.WriteLine("\nEvent not found!");
        }
        else
        {
            Console.WriteLine("\nEvent Details:");
            Console.WriteLine($"ID: {eventDetails.EventId}");
            Console.WriteLine($"Name: {eventDetails.EventName}");
            Console.WriteLine($"Category: {eventDetails.EventCategory}");
            Console.WriteLine($"Date: {eventDetails.EventDate:yyyy-MM-dd}");
            Console.WriteLine($"Description: {eventDetails.Description}");
            Console.WriteLine($"Status: {eventDetails.Status}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateEvent(EventService eventService)
    {
        Console.Clear();
        Console.WriteLine("=== Update Event ===");

        Console.Write("Enter Event ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out var eventId))
        {
            Console.WriteLine("\nInvalid Event ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        var eventDetails = eventService.GetEventById(eventId);

        if (eventDetails == null)
        {
            Console.WriteLine("\nEvent not found!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nLeave blank to keep current value");
        Console.Write($"New Event Name ({eventDetails.EventName}): ");
        var name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name)) eventDetails.EventName = name;

        Console.Write($"New Category ({eventDetails.EventCategory}): ");
        var category = Console.ReadLine();
        if (!string.IsNullOrEmpty(category)) eventDetails.EventCategory = category;

        Console.Write($"New Date ({eventDetails.EventDate:yyyy-MM-dd}): ");
        var dateStr = Console.ReadLine();
        if (DateTime.TryParse(dateStr, out var date)) eventDetails.EventDate = date;

        Console.Write($"New Description ({eventDetails.Description}): ");
        var description = Console.ReadLine();
        if (!string.IsNullOrEmpty(description)) eventDetails.Description = description;

        Console.Write($"New Status ({eventDetails.Status}): ");
        var status = Console.ReadLine();
        if (!string.IsNullOrEmpty(status)) eventDetails.Status = status;

        try
        {
            eventService.UpdateEvent(eventDetails);
            Console.WriteLine("\nEvent updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void DeleteEvent(EventService eventService)
    {
        Console.Clear();
        Console.WriteLine("=== Delete Event ===");

        Console.Write("Enter Event ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out var eventId))
        {
            Console.WriteLine("\nInvalid Event ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        try
        {
            eventService.DeleteEvent(eventId);
            Console.WriteLine("\nEvent deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ViewEventSessions(EventService eventService, SessionService sessionService)
    {
        Console.Clear();
        Console.WriteLine("=== Event Sessions ===");

        Console.Write("Enter Event ID: ");
        if (!int.TryParse(Console.ReadLine(), out var eventId))
        {
            Console.WriteLine("\nInvalid Event ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        var sessions = sessionService.GetSessionsByEventId(eventId);

        if (sessions.Count == 0)
        {
            Console.WriteLine("\nNo sessions found for this event!");
        }
        else
        {
            Console.WriteLine($"\nSessions for Event ID {eventId}:");
            foreach (var session in sessions)
            {
                Console.WriteLine($"Session ID: {session.SessionId}");
                Console.WriteLine($"Title: {session.SessionTitle}");
                Console.WriteLine($"Speaker ID: {session.SpeakerId}");
                Console.WriteLine($"Start: {session.SessionStart:yyyy-MM-dd HH:mm}");
                Console.WriteLine($"End: {session.SessionEnd:yyyy-MM-dd HH:mm}");
                Console.WriteLine("-----------------------");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    #endregion

    #region Session CRUD Operations
    static void AddSession(SessionService sessionService)
    {
        Console.Clear();
        Console.WriteLine("=== Add New Session ===");

        var session = new SessionInfo();

        Console.Write("Event ID: ");
        if (!int.TryParse(Console.ReadLine(), out var eventId))
        {
            Console.WriteLine("\nInvalid Event ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }
        session.EventId = eventId;

        Console.Write("Session Title: ");
        session.SessionTitle = Console.ReadLine();

        Console.Write("Speaker ID: ");
        if (!int.TryParse(Console.ReadLine(), out var speakerId))
        {
            Console.WriteLine("\nInvalid Speaker ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }
        session.SpeakerId = speakerId;

        Console.Write("Description (optional): ");
        session.Description = Console.ReadLine();

        Console.Write("Start Date/Time (yyyy-MM-dd HH:mm): ");
        if (DateTime.TryParse(Console.ReadLine(), out var start))
        {
            session.SessionStart = start;
        }

        Console.Write("End Date/Time (yyyy-MM-dd HH:mm): ");
        if (DateTime.TryParse(Console.ReadLine(), out var end))
        {
            session.SessionEnd = end;
        }

        Console.Write("Session URL (optional): ");
        session.SessionUrl = Console.ReadLine();

        try
        {
            sessionService.AddSession(session);
            Console.WriteLine("\nSession added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ViewAllSessions(SessionService sessionService)
    {
        Console.Clear();
        Console.WriteLine("=== All Sessions ===");

        var sessions = sessionService.GetAllSessions();

        if (sessions.Count == 0)
        {
            Console.WriteLine("No sessions found!");
        }
        else
        {
            foreach (var session in sessions)
            {
                Console.WriteLine($"ID: {session.SessionId}, Title: {session.SessionTitle}, Event ID: {session.EventId}");
                Console.WriteLine($"Start: {session.SessionStart:yyyy-MM-dd HH:mm}, End: {session.SessionEnd:yyyy-MM-dd HH:mm}");
                Console.WriteLine("-----------------------");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ViewSessionDetails(SessionService sessionService)
    {
        Console.Clear();
        Console.WriteLine("=== Session Details ===");

        Console.Write("Enter Session ID: ");
        if (!int.TryParse(Console.ReadLine(), out var sessionId))
        {
            Console.WriteLine("\nInvalid Session ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        var session = sessionService.GetSessionById(sessionId);

        if (session == null)
        {
            Console.WriteLine("\nSession not found!");
        }
        else
        {
            Console.WriteLine("\nSession Details:");
            Console.WriteLine($"ID: {session.SessionId}");
            Console.WriteLine($"Title: {session.SessionTitle}");
            Console.WriteLine($"Event ID: {session.EventId}");
            Console.WriteLine($"Speaker ID: {session.SpeakerId}");
            Console.WriteLine($"Description: {session.Description}");
            Console.WriteLine($"Start: {session.SessionStart:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"End: {session.SessionEnd:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"URL: {session.SessionUrl}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateSession(SessionService sessionService)
    {
        Console.Clear();
        Console.WriteLine("=== Update Session ===");

        Console.Write("Enter Session ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out var sessionId))
        {
            Console.WriteLine("\nInvalid Session ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        var session = sessionService.GetSessionById(sessionId);

        if (session == null)
        {
            Console.WriteLine("\nSession not found!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nLeave blank to keep current value");
        Console.Write($"New Event ID ({session.EventId}): ");
        if (int.TryParse(Console.ReadLine(), out var eventId)) session.EventId = eventId;

        Console.Write($"New Title ({session.SessionTitle}): ");
        var title = Console.ReadLine();
        if (!string.IsNullOrEmpty(title)) session.SessionTitle = title;

        Console.Write($"New Speaker ID ({session.SpeakerId}): ");
        if (int.TryParse(Console.ReadLine(), out var speakerId)) session.SpeakerId = speakerId;

        Console.Write($"New Description ({session.Description}): ");
        var description = Console.ReadLine();
        if (!string.IsNullOrEmpty(description)) session.Description = description;

        Console.Write($"New Start Date/Time ({session.SessionStart:yyyy-MM-dd HH:mm}): ");
        if (DateTime.TryParse(Console.ReadLine(), out var start)) session.SessionStart = start;

        Console.Write($"New End Date/Time ({session.SessionEnd:yyyy-MM-dd HH:mm}): ");
        if (DateTime.TryParse(Console.ReadLine(), out var end)) session.SessionEnd = end;

        Console.Write($"New URL ({session.SessionUrl}): ");
        var url = Console.ReadLine();
        if (!string.IsNullOrEmpty(url)) session.SessionUrl = url;

        try
        {
            sessionService.UpdateSession(session);
            Console.WriteLine("\nSession updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void DeleteSession(SessionService sessionService)
    {
        Console.Clear();
        Console.WriteLine("=== Delete Session ===");

        Console.Write("Enter Session ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out var sessionId))
        {
            Console.WriteLine("\nInvalid Session ID!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        try
        {
            sessionService.DeleteSession(sessionId);
            Console.WriteLine("\nSession deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    #endregion
}