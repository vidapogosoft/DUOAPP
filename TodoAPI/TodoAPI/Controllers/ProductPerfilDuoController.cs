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
    public class ProductPerfilDuoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;

        public ProductPerfilDuoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }


        // GET: ProductPerfilDuoController/Details/5
        [HttpGet("{RegPerfilIdProduct}", Name = "GetProductPerfil")]
        public IActionResult GetProductPerfil(string RegPerfilIdProduct)
        {
            return Ok(_toDoRepository.RegistradoProductPerfil(RegPerfilIdProduct));
        }

    }
}
