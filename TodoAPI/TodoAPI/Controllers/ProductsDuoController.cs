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
    public enum ErrorCodeProducts
    {
        RegistroErrorConexionBase,
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public ProductsDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<ProductsDuoController>
        [HttpGet]
        public IActionResult GetProductsRegistrados()
        {
            return Ok(_toDoRepository.ListProductsRegistradosPerfil);
        }

        // GET api/<ProductsDuoController>/5
        [HttpGet("{RegPerfilId}", Name = "GetProducts")]
        public IActionResult GetProducts(string RegPerfilId)
        {
            return Ok(_toDoRepository.RegistradoProducts(RegPerfilId));
        }

        // POST api/<ProductsDuoController>
        [HttpPost]
        public IActionResult CreateRegister([FromBody] ProductsTnq item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCodeWorks.RegistroErrorConexionBase.ToString());
                }
                _toDoRepository.InsertRegistroProducts(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCodeWorks.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        // PUT api/<ProductsDuoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsDuoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
