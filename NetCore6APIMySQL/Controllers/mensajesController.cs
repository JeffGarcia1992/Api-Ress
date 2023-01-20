using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mensajesController : ControllerBase
    {
        private readonly Imensajesrep _mensajesrep;
        public mensajesController(Imensajesrep mensajesrep)
        {
            _mensajesrep = mensajesrep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMensajes()
        {
            return Ok(await _mensajesrep.GetAllMensajes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _mensajesrep.GetDetails(id));
        }

        [HttpPost]    
        public async Task<IActionResult> InsertMensajes([FromBody]mensajes mensajes)
        {
            if (mensajes == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _mensajesrep.InsertMensajes(mensajes);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMensajes([FromBody] mensajes mensajes)
        {
            if (mensajes == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mensajesrep.UpdateMensajes(mensajes);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMensajes(int id)
        {
            await _mensajesrep.DeleteMensajes(new mensajes {id_mensajes = id });

            return NoContent();
        }

    }
}
