using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Locadora.Controllers
{
    public class CarroController : Controller
    {
        public static List<Carro> marca = new List<Carro>();
        public static List<Carro> car = new List<Carro>();
        public static List<Carro> modelo = new List<Carro>();

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
            if (marca.Any())
            {
                ViewBag.Marca = new SelectList(marca, "Id", "Name");
                return View();
            }
            if (car.Any())
            {
                ViewBag.Carro = new SelectList(car, "Id", "Name");
                return View();
            }
            if (modelo.Any())
            {
                ViewBag.Modelo = new SelectList(modelo, "Id", "Name");
                return View();
            }
            return View();

        }

        public IActionResult BuscarCarros(Carro carro, int drpMarcas)
        {
            string url = "http://fipeapi.appspot.com/api/1/carros/veiculos/" + drpMarcas + ".json";
            WebClient client = new WebClient();
            result = drpMarcas;
            car = JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
            marca.Clear();
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarMarcas()
        {
            string url = "http://fipeapi.appspot.com/api/1/carros/marcas.json";
            WebClient client = new WebClient();
            marca = JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarModelos(Carro carro, int drpCarro)
        {
            string url = "http://fipeapi.appspot.com/api/1/carros/veiculo/" + result + "/" + drpCarro + ".json";
            WebClient client = new WebClient();
            modelo = JsonConvert.DeserializeObject<List<Carro>>(client.DownloadString(url));
            car.Clear();
            return RedirectToAction("Cadastrar");
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