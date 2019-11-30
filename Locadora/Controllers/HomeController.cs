using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Locadora.Models;
using Locadora.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Locadora.Controllers
{
    [AllowAnonymous]
    
    public class HomeController : Controller
    {
       
        private readonly ClienteDAO _clienteDAO;
        private readonly UserManager<ClienteLogado> _userManager;
        private readonly SignInManager<ClienteLogado> _signInManager;

        public HomeController(ClienteDAO clienteDAO, UserManager<ClienteLogado> userManager, SignInManager<ClienteLogado> signInManager)
        {
            
            _clienteDAO = clienteDAO;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var r = RouteData.Values["controller"].ToString();
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Cliente cliente)
        {
            ClienteLogado cLogado = new ClienteLogado
            {
                UserName = cliente.Nome,
                Email = cliente.Cpf
            };

            IdentityResult result = await _userManager.CreateAsync(cLogado, cliente.Senha);
            if (result.Succeeded)
            {
                string codigo = await _userManager.GenerateEmailConfirmationTokenAsync(cLogado);

                await _signInManager.SignInAsync(cLogado, isPersistent: false);

                cliente = _clienteDAO.CadastrarCliente(cliente);
                if (cliente == null)
                {
                    ModelState.AddModelError("", "Cliente já cadastrado!");
                    return View(cliente);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public void AdicionarErros(IdentityResult result)
        {
            foreach (var erro in result.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cpf, string senha)
        {
            Cliente c = new Cliente();
            c = _clienteDAO.AutenticarLogin(cpf, senha);
            Adm adm = new Adm();
            if (cpf.ToUpper().Equals(adm.Login) && senha.ToUpper().Equals(adm.Senha))
            {
                ModelState.AddModelError("", "Login Adm!");
                return RedirectToAction("Index", "Administrador");
            }
            if (c != null)
            {
                if (c.Status.Equals("CANCELADO"))
                {
                    ModelState.AddModelError("", "Sua conta está cancelada, contate o administrador!");
                    return View();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(cpf, senha, true, false);
            if (result.Succeeded)
            {
                HttpContext.Session.SetString("IdCliente", c.IdCliente.ToString());
                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                ModelState.AddModelError("", "Login Invalido!");
                return View();
            }           
            
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
