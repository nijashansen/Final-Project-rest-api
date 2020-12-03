using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void EditUser(User user);
        void RemoveUser(int id);
    }
}
