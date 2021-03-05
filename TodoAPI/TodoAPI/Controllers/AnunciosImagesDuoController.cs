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
    public class AnunciosImagesDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public AnunciosImagesDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }


        // GET: api/<AnunciosImagesDuoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnunciosImagesDuoController>/5
        [HttpGet("{RegIdAnuncioImage}", Name = "GetAnuncioImage")]
        public IActionResult GetAnuncio(string RegIdAnuncioImage)
        {
            return Ok(_toDoRepository.RegistradoAnuncioImages(RegIdAnuncioImage));
        }

        // POST api/<AnunciosImagesDuoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnunciosImagesDuoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnunciosImagesDuoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
