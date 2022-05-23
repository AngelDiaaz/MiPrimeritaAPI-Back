using MiPrimeritaAPI.CORE.DTO;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.BL.Contracts
{
    public interface IUserBL
    {
        public bool Insert(UserDTO u);
        public List<UserDTO> GetUsers();
        public UserDTO? GetUser(string Name);
        public void Update(UserDTO user);
        public void Delete(string Name);
    }
}
