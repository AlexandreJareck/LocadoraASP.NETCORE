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
    public class CatalogoMotoController : Controller
    {

        private readonly MotoDAO _motoDAO;
        private readonly ClienteDAO _clienteDAO;

        public CatalogoMotoController(MotoDAO motoDAO, ClienteDAO clienteDAO)
        {
            _motoDAO = motoDAO;
            _clienteDAO = clienteDAO;
        }

        public IActionResult Index()
        {
            var result = HttpContext.Session.GetString("IdCliente");
            Cliente c = _clienteDAO.Get(Convert.ToInt32(result));
            if (c.PossuiReserva.Equals("SIM"))
            {
                ModelState.AddModelError("", "Você ja Possui uma reserva, faça a devoluação para alugar outro veiculo!");
                return View(_motoDAO.ListarMotosFake());
            }
            if (c.CategoriaCnh.Equals("B"))
            {                
                ModelState.AddModelError("", "Somente Categorias A ou AB!");
                return View(_motoDAO.ListarMotosFake());
            }
            return View(_motoDAO.ListarMotosDisponivel());
        }

        public IActionResult InformacoesMoto(int id)
        {
            return View(_motoDAO.GetId(id));
        }
    }
}