using Microsoft.AspNetCore.Mvc;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.BL.Implementations;
using MiPrimeritaAPI.CORE.DTO;

namespace MiPrimeritaAPI.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public IAlumnoBL alumnoBL { get; set; }

        public AlumnoController(IAlumnoBL alumnoBL)
        {
            this.alumnoBL = alumnoBL;
        }

        [HttpPost]
        [Route("Insert")]
        public ActionResult Insert(AlumnoDTO a) 
        {
            if(alumnoBL.Insert(a))
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("All")]
        public ActionResult<List<AlumnoDTO>> GetAlumnos()
        {
            return Ok(alumnoBL.GetAlumnos());
        }

        [HttpGet]
        public ActionResult<AlumnoDTO?> GetAlumno(string DNI)
        {
            var alumno = alumnoBL.GetAlumno(DNI);
            if (alumno != null)
                return Ok(alumno);
            else
                return NotFound();
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<AlumnoDTO?> Update(AlumnoDTO alumno)
        {
            alumnoBL.Update(alumno);            
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(AlumnoDTO alumno)
        {
            alumnoBL.Delete(alumno.DNI);
            return Ok();            
        }

    }
}
