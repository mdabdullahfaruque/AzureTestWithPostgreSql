using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureContainerTest.API.Entities;

namespace AzureContainerTest.API.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddUserRecord(User user);
        void UpdateUserRecord(User user);
        void DeleteUserRecord(string id);
        User GetUserSingleRecord(string id);
        List<User> GetUserRecords();
    }
}
