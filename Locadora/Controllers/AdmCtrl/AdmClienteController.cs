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

        public static List<Cliente> listClient = new List<Cliente>();

        public AdmClienteController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            ViewBag.DataHora = DateTime.Now;
            if (!listClient.Any())
            {
                return View(_clienteDAO.ListarClientes());
            }
            return View(listClient);
            
        }

        public IActionResult RemoverCliente(int id)
        {
            _clienteDAO.RemoverCliente(id);
            return RedirectToAction("Clientes");
        }

        public IActionResult EditarCliente(int id)
        {
            var result = View(_clienteDAO.Get(id));
            return result;
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {
            _clienteDAO.EditarCliente(cliente);
            return RedirectToAction("Clientes");
        }
        
        public IActionResult BuscarCliente(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                listClient = _clienteDAO.ListarClientes();
            }
            else
            {
                listClient = _clienteDAO.ListClientName(cpf);
            }
            
            return RedirectToAction("Clientes");
        }
    }
}
