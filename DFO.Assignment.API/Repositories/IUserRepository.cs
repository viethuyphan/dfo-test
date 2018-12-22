using System.Collections.Generic;
using DFO.Assignment.Domain.Entities;

namespace DFO.Assignment.API.Repositories
{
    public interface IUserRepository
    {
        int Insert(User user);
        bool Update(User user);
        User FindById(int id);
        IEnumerable<User> GetAll();

        /// <summary>
        /// Check if user exists by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsUserExisted(string name);
    }
}
