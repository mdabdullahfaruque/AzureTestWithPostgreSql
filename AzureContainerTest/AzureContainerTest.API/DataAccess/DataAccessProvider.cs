using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureContainerTest.API.DbContexts;
using AzureContainerTest.API.Entities;

namespace AzureContainerTest.API.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly ApplicationDbContext _context;

        public DataAccessProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUserRecord(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUserRecord(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserRecord(string id)
        {
            var entity = _context.Users.FirstOrDefault(t => t.Id == id);
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public User GetUserSingleRecord(string id)
        {
            return _context.Users.FirstOrDefault(t => t.Id == id);
        }

        public List<User> GetUserRecords()
        {
            return _context.Users.ToList();
        }
    }
}
