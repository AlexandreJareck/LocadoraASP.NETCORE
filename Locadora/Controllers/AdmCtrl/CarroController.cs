using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Locadora.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Locadora.Controllers
{
    public class CarroController : Controller
    {
        public static List<Carro> marcaList = new List<Carro>();
        public static List<Modelo> carList = new List<Modelo>();
        public static List<Carro> modeloList = new List<Carro>();
        public static Carro c = new Carro();

        public static int result;

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

            Carro carro = new Carro();
            if (TempData["Carro"] != null)
            {
                carro = JsonConvert.DeserializeObject<Carro>(TempData["Carro"].ToString());
            }
            ViewBag.Marca = new SelectList(marcaList, "Codigo", "Nome");
            ViewBag.Carro = new SelectList(carList, "Codigo", "Nome");
            ViewBag.Modelo = new SelectList(modeloList, "Codigo", "Nome");
            return View(carro);
        }

        public IActionResult BuscarMarcas()
        {
            marcaList = FipeApiService.BuscarMarcas();
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarCarros(Carro carro)
        {
            try
            {
                c.IdMarca = carro.IdMarca;
                carList = FipeApiService.BuscarCarros(carro);
                TempData["Carro"] = JsonConvert.SerializeObject(carro);

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarModelos(Carro carro)
        {
            try
            {
                c.IdentVeiculo = carro.IdentVeiculo;
                carro.IdMarca = c.IdMarca;
                modeloList = FipeApiService.BuscarModelos(carro);
                TempData["Carro"] = JsonConvert.SerializeObject(carro);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarDadosVeiculo(Carro carro)
        {
            try
            {
                carro.IdentVeiculo = c.IdentVeiculo;
                carro.IdMarca = c.IdMarca;
                carro = FipeApiService.BuscarDadosVeiculo(carro);
                TempData["Carro"] = JsonConvert.SerializeObject(carro);
                carList.Clear();
                modeloList.Clear();

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Cadastrar(Carro carro)
        {
            //if (ModelState.IsValid)
            //{
                carro = _carroDAO.CadastrarCarro(carro);
                if (carro == null)
                {
                    ModelState.AddModelError("", "Carro já cadastrado!");
                    return View(carro);
                }
                return RedirectToAction("Index");
            //}
            //ViewBag.s = "show";
            //return View(carro);
        }

        public IActionResult RemoverCarro(int id)
        {
            _carroDAO.RemoverCarro(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditarCarro(int id)
        {
            return View(_carroDAO.Get(id));
        }

        [HttpPost]
        public IActionResult EditarCarro(Carro carro)
        {
            _carroDAO.EditarCarro(carro);
            return RedirectToAction("Index");
        }
    }
}