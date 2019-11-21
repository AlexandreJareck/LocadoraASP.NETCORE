using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers.ClienteCtrl
{
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

        //public IActionResult RemoverCliente(int id)
        //{
        //    _clienteDAO.RemoverCliente(id);
        //    return RedirectToAction("Index","Home");
        //}
    }
}