using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;

namespace MiPrimeritaAPI.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
            public ILoginBL LoginBL { get; set; }
            public LoginController(ILoginBL loginBL)
            {
                this.LoginBL = loginBL;
            }

            [HttpPost]
            public bool CheckLogin(LoginDTO loginDTO)
            {
                return LoginBL.CheckLogin(loginDTO.Name, loginDTO.Password);
                    
            }
    }
}
