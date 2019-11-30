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
    [Route("api/Moto")]
    [ApiController]
    public class MotoApiController : ControllerBase
    {
        private readonly MotoDAO _motoDAO;

        public MotoApiController(MotoDAO motoDAO)
        {
            _motoDAO = motoDAO;
        }

        //GET: api/Moto/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            return Ok(_motoDAO.ListarMotos());
        }

        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public IActionResult ListarTodos(int id)
        {
            Moto m = new Moto();
            m = _motoDAO.GetId(id);
            if (m != null)
            {
                return Ok();
            }
            return NotFound(new { msg = "Esse produto não existe!" });
        }
    }
}