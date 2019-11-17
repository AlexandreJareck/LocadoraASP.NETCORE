using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers.ClienteCtrl
{
    public class ClienteController : Controller
    {
        private readonly CarroDAO _carroDAO;
        private readonly MotoDAO _motoDAO;

        //private readonly ClienteDAO _clienteDAO;

        public ClienteController(CarroDAO carroDAO, MotoDAO motoDAO)
        {
            _motoDAO = motoDAO;
            _carroDAO = carroDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListCarro()
        {
            return View(_carroDAO.ListarCarrosDs());
        }

        public IActionResult ListMoto()
        {
            return View(_motoDAO.ListarMotosDs());
        }

        public IActionResult CatalogoCarro()
        {
            return View(_carroDAO.ListarCarrosDs());
        }

        public IActionResult DetalhesCarro(int id)
        {
            return View(_carroDAO.GetId(id));
        }

        public IActionResult CatalogoMoto()
        {
            return View(_motoDAO.ListarMotosDs());
        }
        public IActionResult DetalhesMoto(int id)
        {
            return View(_motoDAO.GetId(id));
        }

        //public IActionResult RemoverCliente(int id)
        //{
        //    _clienteDAO.RemoverCliente(id);
        //    return RedirectToAction("Index","Home");
        //}
    }
}