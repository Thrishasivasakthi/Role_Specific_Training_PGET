
using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly EventDbContext _context;

        public UserRepository(EventDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<UserInfo> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public UserInfo GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.EmailId == email);
        }

        public void RemoveUser(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.EmailId == email);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUser(UserInfo user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.EmailId == user.EmailId);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Role = user.Role;
                existingUser.Password = user.Password;
                _context.SaveChanges();
            }
        }
    }
}