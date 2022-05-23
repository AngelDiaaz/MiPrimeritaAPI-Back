using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public IESContext Context { get; set; }

        public UserDAL(IESContext Context)
        { 
            this.Context = Context;
        }
        public void Delete(string Name)
        {
            var users = GetUser(Name);
            if (users != null)
                Context.User.Remove(users);
            Context.SaveChanges();
        }

        public User? GetUser(string Name)
        {
            return Context.User.FirstOrDefault(u => u.Name == Name);
        
        }

        public List<User> GetUsers()
        {
            return Context.User.ToList();
        }

        public void Insert(User u)
        {
            Context.User.Add(u);
            Context.SaveChanges();
        }

        public void Update(User u)
        {

            var userBD = GetUser(u!.Name);
            if (userBD != null)
            {
                userBD.Name = u.Name;
            }
            Context.User.Update(userBD);
            Context.SaveChanges();
        }
    }
}

