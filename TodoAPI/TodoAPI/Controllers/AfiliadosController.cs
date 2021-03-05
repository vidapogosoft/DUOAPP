using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TodoAPI.Interfaces;
using TodoAPI.Models;


namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    
    public class AfiliadosController : ControllerBase
    {

        private readonly IToDoRepository _toDoRepository;

        public AfiliadosController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/Afiliados
        [HttpGet]
        public IActionResult GetAfiliados()
        {
            return Ok(_toDoRepository.ListAfiliados);
        }

        // GET: api/Afiliados/5
        [HttpGet("{IdAfiliado}", Name = "Get")]
        public IActionResult GetAfiliado(int IdAfiliado)
        {
            return Ok(_toDoRepository.Afiliado(IdAfiliado));
        }

        // POST: api/Afiliados
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Afiliados/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
