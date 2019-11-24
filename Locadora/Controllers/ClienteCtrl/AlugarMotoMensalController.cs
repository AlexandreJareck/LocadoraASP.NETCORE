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
    public class AlugarMotoMensalController : Controller
    {
        public static int Id;

        private readonly MotoDAO _motoDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly ReservaDAO _reservaDAO;

        public AlugarMotoMensalController(MotoDAO motoDAO, ClienteDAO clienteDAO, ReservaDAO reservaDAO)
        {
            _motoDAO = motoDAO;
            _clienteDAO = clienteDAO;
            _reservaDAO = reservaDAO;
        }

        public IActionResult AluguelMensal(int id)
        {
            Id = id;
            var result = View(_motoDAO.GetId(id));
            return result;
        }

        [HttpPost]
        public IActionResult AluguelMensal(Moto moto, DateTime dtAluguel)
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");
            _reservaDAO.ReservaMensalMoto(moto, dtAluguel, idCliente);
            return RedirectToAction("Index", "Cliente");
        }
    }
}