using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.BL.Contracts
{
    public interface ILoginBL
    {
        public bool CheckLogin(string username, string password);
    }
}
