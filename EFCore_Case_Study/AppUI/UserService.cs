// UserService.cs
using System.Collections.Generic;
using DAL.DataAccess;
using DAL.Models;

namespace AppUI
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserInfo user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(UserInfo user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(string email)
        {
            _userRepository.RemoveUser(email);
        }

        public UserInfo GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public List<UserInfo> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}