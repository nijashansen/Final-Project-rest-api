using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly ErrorContext _ctx;

        public UserRepository(ErrorContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }

        public User GetUserById(int id)
        {
            return _ctx.Users.FirstOrDefault(b => b.Id == id);
        }

        public void AddUser(User entity)
        {
            _ctx.Users.Add(entity);
            _ctx.SaveChanges();
        }

        public void EditUser(User entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            var item = _ctx.Users.FirstOrDefault(b => b.Id == id);
            _ctx.Users.Remove(item);
            _ctx.SaveChanges();
        }
    }
}
