using AutoMapper;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;
using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.BL.Implementations
{
    public class UserBL : IUserBL
    {
        public IUserDAL userDAL { get; set; }
        public IMapper mapper { get; set; }

        public UserBL(IUserDAL userDAL, IMapper mapper)
        {
            this.userDAL = userDAL;
            this.mapper = mapper;
        }
        public void Delete(string Name)
        {
            userDAL.Delete(Name);
        }

        public UserDTO? GetUser(string Name)
        {
            var user = userDAL.GetUser(Name);
            if (user != null)
            {
                //var alumnoDTO = new AlumnoDTO()
                //{
                //    DNI = alumno.DNI,
                //    Nombre = alumno.Nombre,
                //    PIN = alumno.PIN
                //};
                var userDTO = mapper.Map<UserDTO>(user);
                return userDTO;
            }
            else
            {
                return null;
            }
        }

        public List<UserDTO> GetUsers()
        {
            var users = userDAL.GetUsers();
            var userDTOs = mapper.Map<List<UserDTO>>(users);
            return userDTOs;
        }

        public bool Insert(UserDTO userDTO)
        {
            var user = userDAL.GetUser(userDTO.Name);
            if (user == null)
            {
                user = mapper.Map<User>(userDTO);

                userDAL.Insert(user);
                //Enviar email
                return true;
            }
            return false;
        }

        public void Update(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            userDAL.Update(user);
        }
        
    }
}

