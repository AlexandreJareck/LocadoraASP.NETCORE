using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [Route("api/Carro")]
    [ApiController]
    public class CarroApiController : ControllerBase
    {
        private readonly CarroDAO _carroDAO;

        public CarroApiController(CarroDAO carroDAO)
        {
            _carroDAO = carroDAO;
        }

        //GET: api/Carro/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_carroDAO.ListarCarros());
        }

        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public IActionResult ListarTodos(int id)
        {
            Carro c = new Carro();
            c = _carroDAO.GetId(id);
            if(c != null)
            {
                return Ok();
            }
            return NotFound(new { msg = "Esse produto não existe!" });
        }
    }
}