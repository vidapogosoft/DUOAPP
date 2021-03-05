using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using TodoAPI.Interfaces;
using TodoAPI.Models;


namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksPerfilDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public WorksPerfilDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<WorksPerfilDuoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WorksPerfilDuoController>/5
        [HttpGet("{IdWorks}", Name = "GetWorkId")]
        public IActionResult GetWork(string IdWorks)
        {
            return Ok(_toDoRepository.WorksPerfil(IdWorks));
        }

        // POST api/<WorksPerfilDuoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorksPerfilDuoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorksPerfilDuoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
