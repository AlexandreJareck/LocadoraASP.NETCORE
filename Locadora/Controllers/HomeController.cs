using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Locadora.Models;
using Locadora.DAL;

namespace Locadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClienteDAO _clienteDAO;

        public HomeController(ClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string cpf, string senha)
        {
            Adm adm = new Adm();
            if (_clienteDAO.AutenticarLogin(cpf, senha))
            {
                ModelState.AddModelError("", "Login OK!");
                return View();
            }
            else if (cpf.ToUpper().Equals(adm.Login) && senha.ToUpper().Equals(adm.Senha))
            {
                ModelState.AddModelError("", "Login Adm!");
                return RedirectToAction("Index", "Administrador");
            }
            else
            {
                ModelState.AddModelError("", "Login Invalido!");
                return View();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            cliente = _clienteDAO.CadastrarCliente(cliente);
            if (cliente == null)
            {
                ModelState.AddModelError("", "Cliente já cadastrado!");
                return View(cliente);
            }
            return RedirectToAction("Index");
        }
    }
}
