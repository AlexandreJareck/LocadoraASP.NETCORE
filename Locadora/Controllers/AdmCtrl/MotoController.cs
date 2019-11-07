using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    public class MotoController : Controller
    {
        private readonly MotoDAO _motoDAO;

        public MotoController(MotoDAO motoDAO)
        {
            _motoDAO = motoDAO;
        }

        public IActionResult Index()
        {
            return View(_motoDAO.ListarMotos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Moto moto)
        {
            moto = _motoDAO.CadastrarMoto(moto);
            if (moto == null)
            {
                ModelState.AddModelError("", "Moto já cadastrada!");
                return View(moto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverMoto(int id)
        {
            _motoDAO.RemoverMoto(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditarMoto(int id)
        {
            var result = View(_motoDAO.Get(id));
            return result;
        }

        [HttpPost]
        public IActionResult EditarMoto(Moto moto)
        {
            _motoDAO.EditarMoto(moto);
            return RedirectToAction("Index");
        }
    }
}