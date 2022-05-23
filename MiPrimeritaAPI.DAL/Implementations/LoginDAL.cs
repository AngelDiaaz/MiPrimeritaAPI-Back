using MiPrimeritaAPI.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Implementations
{
    public class LoginDAL : ILoginDAL
    {
        public UserDAL UserDAL;
        public IESContext Context { get; set; }

        public LoginDAL(IESContext Context)
        {
            this.Context = Context;
        }

        public bool CheckLogin(string username, string password)
        {
            var user = UserDAL.GetUser(username);
            if (user.Name == username && user.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
