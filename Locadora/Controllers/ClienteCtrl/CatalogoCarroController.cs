using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers.ClienteCtrl
{
    public class CatalogoCarroController : Controller
    {
        private readonly CarroDAO _carroDAO;
        private readonly ClienteDAO _clienteDAO;

        public CatalogoCarroController(CarroDAO carroDAO, ClienteDAO clienteDAO)
        {
            _carroDAO = carroDAO;
            _clienteDAO = clienteDAO;
        }

        public IActionResult Index()
        {
            var result = HttpContext.Session.GetString("IdCliente");
            Cliente c = _clienteDAO.Get(Convert.ToInt32(result));
            if (c.CategoriaCnh.Equals("A"))
            {
                ModelState.AddModelError("", "Somente Categorias B ou AB!");
                return View(_carroDAO.ListarCarrosFake());
            }
            return View(_carroDAO.ListarCarrosDisponivel());
        }


        public IActionResult InformacoesCarro(int id)
        {
            return View(_carroDAO.GetId(id));
        }
    }
}