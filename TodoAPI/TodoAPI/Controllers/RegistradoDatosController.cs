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
    public class RegistradoDatosController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public RegistradoDatosController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<RegistradoDatosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RegistradoDatosController>/5
        [HttpGet("{IdRegistrado}", Name = "GetById")]
        public IActionResult GetRegistradoById(string IdRegistrado)
        {
            return Ok(_toDoRepository.RegistradoById(IdRegistrado));
        }

        // POST api/<RegistradoDatosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RegistradoDatosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistradoDatosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
