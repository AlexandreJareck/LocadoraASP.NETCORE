using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers.ClienteCtrl
{
    [Authorize]
    public class ClienteController : Controller
    {


        private readonly ClienteDAO _clienteDAO;

        public ClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        public IActionResult Index()
        {
            //var result = HttpContext.Session.GetString("IdCliente");
            return View();
        }

        public IActionResult ConfigConta()
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");

            return View(_clienteDAO.ListClientId(Convert.ToInt32(idCliente)));
        }
        
        public IActionResult ClientCancel(int id) // removeClient
        {
            Cliente c = new Cliente();
            c = _clienteDAO.Get(id);
            if (c.PossuiReserva.Equals("SIM"))
            {
                TempData["AlertMessage"] = "Você possui uma reserva, faça a devolução para poder cancelar sua conta!";
                return RedirectToAction("ConfigConta");
            }
            _clienteDAO.RemoverCliente(id);
            HttpContext.Session.Remove("IdCliente");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ClientEdit(int id)
        {
            var result = View(_clienteDAO.Get(id));
            return result;
        }

        [HttpPost]
        public IActionResult ClientEdit(Cliente cliente)
        {
            _clienteDAO.EditarCliente(cliente);
            return RedirectToAction("ConfigConta");
        }
    }
}