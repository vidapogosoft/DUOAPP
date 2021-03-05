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

    public enum ErrorCode2
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
    public class RegistradoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public RegistradoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<RegistradoController>
        [HttpGet]
        public IActionResult GetRegistrados()
        {
            return Ok(_toDoRepository.ListRegistrados);
        }

        // GET api/<RegistradoController>/5
        [HttpGet("{EmailRegistrado}", Name = "Get")]
        public IActionResult GetRegistrado(string EmailRegistrado)
        {
            return Ok(_toDoRepository.Registrado(EmailRegistrado));
        }

        // POST api/<RegistradoController>
        [HttpPost]
        
        public IActionResult CreateRegister([FromBody] Registrado item)
        {
            try
            {

                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode2.RegistroErrorConexionBase.ToString());
                }
                _toDoRepository.InsertRegistro(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode2.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        // PUT api/<RegistradoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistradoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
