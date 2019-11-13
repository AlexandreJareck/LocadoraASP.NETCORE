using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Locadora.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Locadora.Controllers
{
    public class MotoController : Controller
    {
        public static List<Moto> marcaList = new List<Moto>();
        public static List<Modelo> motoList = new List<Modelo>();
        public static List<Moto> modeloList = new List<Moto>();
        public static Moto m = new Moto();

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

            Moto moto = new Moto();
            if (TempData["Moto"] != null)
            {
                moto = JsonConvert.DeserializeObject<Moto>(TempData["Moto"].ToString());
            }
            ViewBag.Marca = new SelectList(marcaList, "Codigo", "Nome");
            ViewBag.Moto = new SelectList(motoList, "Codigo", "Nome");
            ViewBag.Modelo = new SelectList(modeloList, "Codigo", "Nome");
            return View(moto);
        }

        public IActionResult BuscarMarcas()
        {
            marcaList = FipeApiService.BuscarMarcasMoto();
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarMotos(Moto moto)
        {
            try
            {
                m.IdMarca = moto.IdMarca;
                motoList = FipeApiService.BuscarMotos(moto);
                TempData["Moto"] = JsonConvert.SerializeObject(moto);

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarModelosMoto(Moto moto)
        {
            try
            {
                m.IdentVeiculo = moto.IdentVeiculo;
                moto.IdMarca = m.IdMarca;
                modeloList = FipeApiService.BuscarModelosMoto(moto);
                TempData["Moto"] = JsonConvert.SerializeObject(moto);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Cadastrar");
        }

        public IActionResult BuscarDadosVeiculo(Moto moto)
        {
            try
            {
                moto.IdentVeiculo = m.IdentVeiculo;
                moto.IdMarca = m.IdMarca;
                moto = FipeApiService.BuscarDadosVeiculoMoto(moto);
                TempData["Moto"] = JsonConvert.SerializeObject(moto);
                motoList.Clear();
                modeloList.Clear();

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Cadastrar(Moto moto)
        {
            moto.IdentVeiculo = null;
            moto.IdMarca = null;
            moto.IdModelo = null;
            if (ModelState.IsValid)
            {
                moto = _motoDAO.CadastrarMoto(moto);
                if (moto == null)
                {
                    ModelState.AddModelError("", "Moto já cadastrado!");
                    return View(moto);
                }
                return RedirectToAction("Index");
            }
            ViewBag.s = "show";
            return View(moto);
        }

        public IActionResult RemoverMoto(int id)
        {
            _motoDAO.RemoverMoto(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditarMoto(int id)
        {
            return View(_motoDAO.Get(id));
        }

        [HttpPost]
        public IActionResult EditarMoto(Moto moto)
        {
            _motoDAO.EditarMoto(moto);
            return RedirectToAction("Index");
        }

    }
}