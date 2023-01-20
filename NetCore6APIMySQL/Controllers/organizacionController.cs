using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class organizacionController : ControllerBase
    {
        private readonly Iorganizacionrep _organizacionrep;
        public organizacionController(Iorganizacionrep organizacionrep)
        {
            _organizacionrep = organizacionrep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrganizacions()
        {
            return Ok(await _organizacionrep.GetAllOrganizacions());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _organizacionrep.GetDetails(id));
        }

        [HttpPost]    
        public async Task<IActionResult> InsertOrganizacion([FromBody]organizacion organizacion)
        {
            if (organizacion == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _organizacionrep.InsertOrganizacion(organizacion);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrganizacion([FromBody] organizacion organizacion)
        {
            if (organizacion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _organizacionrep.UpdateOrganizacion(organizacion);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrganizacion(int id)
        {
            await _organizacionrep.DeleteOrganizacion(new organizacion {id_organizacion = id });

            return NoContent();
        }

    }
}
