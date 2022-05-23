using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.BL.Implementations
{
    public class LoginBL : ILoginBL
    {
        public IUserBL UserBL;
        public IESContext Context { get; set; }

        public LoginBL(IESContext Context, IUserBL UserBL)
        {
            this.Context = Context;
            this.UserBL = UserBL;
        }

        public bool CheckLogin(string Name, string password)
        {
            var user = UserBL.GetUser(Name);

            if (user == null) return false;

            if (user.Name == Name && user.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
