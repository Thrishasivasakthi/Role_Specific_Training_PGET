using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IUserRepository
    {
        void AddUser(UserInfo user);
        void RemoveUser(string email);
        void UpdateUser(UserInfo user);
        UserInfo GetUserByEmail(string email);
        List<UserInfo> GetAllUsers();
    }
}
