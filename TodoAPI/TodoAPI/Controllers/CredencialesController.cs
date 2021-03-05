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
    public class CredencialesController : ControllerBase
    {

        private readonly IToDoRepository _toDoRepository;

        public CredencialesController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

           // GET api/<CredencialesDuoController>/1/2
        [HttpGet("{Login}/{Pwd}", Name = "GetSession")]
        public IActionResult GetSession(string Login, string Pwd)
        {
            return Ok(_toDoRepository.GetCredenciales(Login, Pwd));
        }



    }

}