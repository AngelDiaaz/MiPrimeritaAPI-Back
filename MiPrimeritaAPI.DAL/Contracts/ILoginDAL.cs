using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Contracts
{
    public interface ILoginDAL
    {
        public bool CheckLogin(string username, string password);
    }
}
