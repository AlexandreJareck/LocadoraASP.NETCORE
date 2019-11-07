using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    public class CarroController : Controller
    {
        private readonly CarroDAO _carroDAO;

        public CarroController(CarroDAO carroDAO)
        {
            _carroDAO = carroDAO;
        }

        public IActionResult Index()
        {
            return View(_carroDAO.ListarCarros());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Carro carro)
        {
            carro = _carroDAO.CadastrarCarro(carro);
            if (carro == null)
            {
                ModelState.AddModelError("", "Carro já cadastrado!");
                return View(carro);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverCarro(int id)
        {
            _carroDAO.RemoverCarro(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditarCarro(int id)
        {
            var result = View(_carroDAO.Get(id));
            return result;
        }

        [HttpPost]
        public IActionResult EditarCarro(Carro carro)
        {
            _carroDAO.EditarCarro(carro);
            return RedirectToAction("Index");
        }
    }
}