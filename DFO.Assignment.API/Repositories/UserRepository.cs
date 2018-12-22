using System;
using System.Collections.Generic;
using System.Linq;
using DFO.Assignment.Domain.Entities;

namespace DFO.Assignment.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User { Id = 1, Name ="Oliver", Age = 20, Address = "39 Acacia Avenue"},
            new User { Id = 2, Name ="George", Age = 22, Address = "501a Halfway Street"},
            new User { Id = 3, Name ="Harry", Age = 23, Address = "Casilla de Correo 432"},
            new User { Id = 4, Name ="Jack", Age = 24, Address = "Escuela Rural 45"},
            new User { Id = 5, Name ="Jacob", Age = 40, Address = "Calle 39 No 1540"},
        };

        private static int GetNextSequence()
        {
            return Users.Max(p => p.Id) + 1;
        }

        public int Insert(User user)
        {
            user.Id = GetNextSequence();
            Users.Add(user);

            return user.Id;
        }

        public bool Update(User user)
        {
            var index = Users.FindIndex(p => p.Id == user.Id);

            if (index < 0)
            {
                return false;
            }

            Users[index] = user;

            return true;
        }

        public User FindById(int id)
        {
            return Users.Find(p => p.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public bool IsUserExisted(string name)
        {
            return Users.Exists(p => p.Name == name);
        }
    }
}
