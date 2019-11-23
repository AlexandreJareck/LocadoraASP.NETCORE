using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Locadora.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public static List<Moto> listMotoPlaca = new List<Moto>();
        public static Moto m = new Moto();

        private readonly MotoDAO _motoDAO;
        private readonly IHostingEnvironment _hosting;

        public MotoController(MotoDAO motoDAO, IHostingEnvironment hosting)
        {
            _motoDAO = motoDAO;
            _hosting = hosting;
        }
        

        public IActionResult Index()
        {
            if (!listMotoPlaca.Any())
            {
                return View(_motoDAO.ListarMotos());
            }
            return View(listMotoPlaca);
        }

        public IActionResult BuscarMotoPlaca(string placa)
        {

            if (string.IsNullOrWhiteSpace(placa))
            {
                listMotoPlaca = _motoDAO.ListarMotos();
            }
            else
            {
                listMotoPlaca = _motoDAO.ListMotoPlaca(placa);
            }

            return RedirectToAction("Index");
        }

        #region Crud

        public IActionResult Cadastrar()
        {
            Moto moto = new Moto();
            try
            {
                if (TempData["Moto"] != null)
                {
                    moto = JsonConvert.DeserializeObject<Moto>(TempData["Moto"].ToString());
                }
                ViewBag.Marca = new SelectList(marcaList, "Codigo", "Nome");
                ViewBag.Moto = new SelectList(motoList, "Codigo", "Nome");
                ViewBag.Modelo = new SelectList(modeloList, "Codigo", "Nome");
            }
            catch (Exception) { }//tratar mensagem de retorno
            return View(moto);
        }

        [HttpPost]
        public IActionResult Cadastrar(Moto moto, IFormFile fupImagem)
        {
            try
            {
                if ((moto.ValorPorDia == 0 || moto.ValorPorDia < 0))
                {
                    ModelState.AddModelError("", "Somente valores positivos em: Valor Dia!");
                    return View(moto);
                }
                if ((moto.ValorPorHora == 0 || moto.ValorPorHora < 0))
                {
                    ModelState.AddModelError("", "Somente valores positivos em: Valor Hora!");
                    return View(moto);
                }
                if (moto.Placa == null || moto.Modelo == null)
                {
                    ModelState.AddModelError("", "Campos com * são Obrigatório!");
                    return View(moto);
                }
                if (ModelState.IsValid)
                {
                    if (fupImagem != null)
                    {
                        string arquivo = Guid.NewGuid().ToString() + Path.GetExtension(fupImagem.FileName);
                        string caminho = Path.Combine(_hosting.WebRootPath, "locadoraimagens", arquivo);
                        fupImagem.CopyTo(new FileStream(caminho, FileMode.Create));
                        moto.Imagem = arquivo;
                    }
                    else
                    {
                        moto.Imagem = "SEM-IMAGEM-13.jpg";
                    }
                    moto = _motoDAO.CadastrarMoto(moto);
                    if (moto == null)
                    {
                        ModelState.AddModelError("", "Moto já cadastrado!");
                        return View(moto);
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.s = "show";
            }
            catch (Exception){ }//tratar mensagem de retorno
            return View(moto);
        }

        public IActionResult RemoverMoto(int id)
        {
            _motoDAO.RemoverMoto(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditarMoto(int id)
        {
            return View(_motoDAO.GetId(id));
        }

        [HttpPost]
        public IActionResult EditarMoto(Moto moto)
        {
            _motoDAO.EditarMoto(moto);
            return RedirectToAction("Index");
        }

        public void SalvaImg(Moto moto, IFormFile fupImagem)
        {
            string arquivo = Guid.NewGuid().ToString() + Path.GetExtension(fupImagem.FileName);
            string caminho = Path.Combine(_hosting.WebRootPath, "locadoraimagens", arquivo);
            fupImagem.CopyTo(new FileStream(caminho, FileMode.Create));
            moto.Imagem = arquivo;
        }

        #endregion

        #region WebServices

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

        #endregion

    }
}