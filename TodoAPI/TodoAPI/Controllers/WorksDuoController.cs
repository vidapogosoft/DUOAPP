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

    public enum ErrorCodeWorks
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
    public class WorksDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public WorksDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: api/<WorksDuoController>
        [HttpGet]
        public IActionResult GetWorksRegistrados()
        {
            return Ok(_toDoRepository.ListWorksRegistradosPerfil);
        }

        // GET api/<WorksDuoController>/5
        [HttpGet("{RegPerfilId}", Name = "GetWorks")]
        public IActionResult GetWorks(string RegPerfilId)
        {
            return Ok(_toDoRepository.RegistradoWorks(RegPerfilId));
        }

        // POST api/<WorksDuoController>
        [HttpPost]
        public IActionResult CreateRegister([FromBody] WorksTnq item)
        {
            try
            {

                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCodeWorks.RegistroErrorConexionBase.ToString());
                }
                _toDoRepository.InsertRegistroWorks(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCodeWorks.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        // PUT api/<WorksDuoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorksDuoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
