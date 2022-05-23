using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;

namespace MiPrimeritaAPI.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
            public IUserBL UserBL { get; set; }

            public UserController(IUserBL userBL) => this.UserBL = userBL;

            /// <summary>
            /// Esto sirve para insertar un alumno.
            /// </summary>
            /// <param name="a">Alumno a insertar.</param>
            [HttpPost]
            public ActionResult Insert(UserDTO u)
            {
                if (UserBL.Insert(u))
                    return Ok();
                return BadRequest();
            }

            [HttpGet]
            [Route("All")]
            public ActionResult<List<UserDTO>> GetAlumnos()
            {
                return Ok(UserBL.GetUsers());
            }

            [HttpGet]
            public ActionResult<UserDTO?> GetUser(string Name)
            {
                var user = UserBL.GetUser(Name);
                if (user != null)
                    return Ok(user);
                else
                    return NotFound();
            }

            [HttpPut]
            public ActionResult<UserDTO?> Update(UserDTO user)
            {
                UserBL.Update(user);
                return Ok();
            }

            [HttpDelete]
            public ActionResult Delete(string Name)
            {
                UserBL.Delete(Name);
                return Ok();
            }
        }

    
        
    
}
