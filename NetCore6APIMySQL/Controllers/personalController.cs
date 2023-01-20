using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personalController : ControllerBase
    {
        private readonly Ipersonalrep _personalrep;
        public personalController(Ipersonalrep personalrep)
        {
            _personalrep = personalrep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersonal()
        {
            return Ok(await _personalrep.GetAllPersonal());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _personalrep.GetDetails(id));
        }

        [HttpPost]    
        public async Task<IActionResult> InsertPersonal([FromBody]personal personal)
        {
            if (personal == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _personalrep.InsertPersonal(personal);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonal([FromBody] personal personal)
        {
            if (personal == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personalrep.UpdatePersonal(personal);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMensajes(int id)
        {
            await _personalrep.DeletePersonal(new personal {id_personal = id });

            return NoContent();
        }

    }
}
