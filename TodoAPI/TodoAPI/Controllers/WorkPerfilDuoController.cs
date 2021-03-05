using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TodoAPI.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPerfilDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public WorkPerfilDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // GET: WorkPerfilDuoController
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: WorkPerfilDuoController/Details/5
        [HttpGet("{RegPerfilIdWork}", Name = "GetWorkPerfil")]
        public IActionResult GetWorkPerfil(string RegPerfilIdWork)
        {
            return Ok(_toDoRepository.RegistradoPerfilWork(RegPerfilIdWork));
        }

  
    }
}
