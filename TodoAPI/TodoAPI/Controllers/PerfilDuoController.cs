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

    public enum ErrorCodePerfil
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
    public class PerfilDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public PerfilDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<PerfilDuoController>
        [HttpGet]
        public IActionResult GetRegistrados()
        {
            return Ok(_toDoRepository.ListRegistradosPerfil);
        }

        // GET api/<PerfilDuoController>/5
        [HttpGet("{EmailRegistrado}", Name = "GetPerfil")]
        public IActionResult GetRegistradoPerfil(string EmailRegistrado)
        {
            return Ok(_toDoRepository.RegistradoPerfil(EmailRegistrado));
        }

        // POST api/<PerfilDuoController>
        [HttpPost]
        public IActionResult CreateRegister([FromBody] PerfilDuoTnq item)
        {
            try
            {

                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCodePerfil.RegistroErrorConexionBase.ToString());
                }
                _toDoRepository.InsertRegistroPerfil(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCodePerfil.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        // PUT api/<PerfilDuoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PerfilDuoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
