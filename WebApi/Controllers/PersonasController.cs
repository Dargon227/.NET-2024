using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IBL_Persona _persona;

        public PersonasController(IBL_Persona _bl)
        {
            _persona = _bl;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return _persona.GetPersonas();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            return _persona.GetPersona(id);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public Persona Post([FromBody] Persona value)
        {
            return _persona.AddPersona(value);
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public Persona Put(int id, [FromBody] Persona value)
        {
            return _persona.UpdatePersona(value);
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _persona.DeletePersona(id);
        }
    }
}
