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
    public class AnunciosDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public AnunciosDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }


        // GET: api/<AnunciosDuoController>
        [HttpGet]
        public IActionResult GetAnuncios()
        {
            return Ok(_toDoRepository.RegistradoAnuncios);
        }

        // GET api/<AnunciosDuoController>/5
        [HttpGet("{RegIdAnuncio}", Name = "GetAnuncio")]
        public IActionResult GetAnuncio(string RegIdAnuncio)
        {
            return Ok(_toDoRepository.RegistradoAnuncio(RegIdAnuncio));
        }

        // POST api/<AnunciosDuoController>
        [HttpPost]
        public IActionResult CreateRegister([FromBody] AnuncioTnq item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCodeWorks.RegistroErrorConexionBase.ToString());
                }
                _toDoRepository.InsertRegistroAnuncio(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCodeWorks.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }

        // PUT api/<AnunciosDuoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnunciosDuoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
