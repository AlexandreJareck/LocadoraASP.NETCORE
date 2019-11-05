using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers.AdmCtrl
{
    public class AdmClienteController : Controller
    {
        private readonly ClienteDAO _clienteDAO;

        public AdmClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        public IActionResult Clientes()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_clienteDAO.ListarClientes());
        }

        public IActionResult RemoverCliente(int id)
        {
            _clienteDAO.RemoverCliente(id);
            return RedirectToAction("Clientes");
        }

        public IActionResult EditarCliente(int id)
        {
            return View(_clienteDAO.Get(id));
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {
            _clienteDAO.EditarCliente(cliente);
            return RedirectToAction("Clientes");
        }
    }
}
