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

        [HttpPost]
        [Route("Register")]
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
        public ActionResult<UserDTO?> GetUser(UserDTO user)
        {
            var u = UserBL.GetUser(user.Name);
            if (u != null)
                return Ok(u);
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
        public ActionResult Delete(UserDTO user)
        {
            UserBL.Delete(user.Name);
            return Ok();
        }
    }
    
}
