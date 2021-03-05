using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TodoAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public RestaurantesController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<RestaurantesController>
        [HttpGet]
        public IActionResult GetRestaurantes()
        {
            return Ok(_toDoRepository.ListRestaurantes);
        }

        // GET api/<RestaurantesController>/5
        [HttpGet("{IdAfiliadoRestaurant}")]
        public IActionResult GetRestaurant(int IdAfiliadoRestaurant)
        {
            return Ok(_toDoRepository.Afiliado(IdAfiliadoRestaurant));
        }

        // POST api/<RestaurantesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestaurantesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
