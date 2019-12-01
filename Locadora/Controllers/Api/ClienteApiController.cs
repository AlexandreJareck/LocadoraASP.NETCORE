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
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteApiController : ControllerBase
    {
        private readonly ClienteDAO _clienteDAO;

        public ClienteApiController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            var result = _clienteDAO.ListarClientes();
            return Ok(_clienteDAO.ListarClientes());
        }

        [HttpDelete]
        [Route("RemoverCliente/{id}")]
        public IActionResult RemoveClient(int id)
        {
            try
            {
                Cliente cliente = _clienteDAO.Get(id);
                if (cliente != null)
                {
                    if (cliente.PossuiReserva.Equals("SIM") || cliente.Status.Equals("PENDENTE"))
                    {
                        return Conflict(new { msg = "Esse Possui uma Reserva pendente, façã a devolução para pode cancelar essa conta!" });
                    }
                    _clienteDAO.RemoverCliente(id);
                    return Created("", cliente);
                }
                return Conflict(new { msg = "Esse Cliente não existe !" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpPut]
        //[Route("EditarCliente/{id}")]
        //public IActionResult UpdateClient(int id, Cliente cliente)
        //{
        //    try
        //    {
        //        Cliente c = _clienteDAO.Get(id);
        //        if (c != null)
        //        {                 
                    
        //            _clienteDAO.EditarCliente(cliente);
        //            return Created("", cliente);
        //        }
        //        return Conflict(new { msg = "Esse Cliente não existe !" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}