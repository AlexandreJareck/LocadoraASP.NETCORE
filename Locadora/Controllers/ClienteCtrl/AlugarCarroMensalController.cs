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
    public class AlugarCarroMensalController : Controller
    {
        public static int Id;

        private readonly CarroDAO _carroDAO;
        private readonly ClienteDAO _clienteDAO;        
        private readonly ReservaDAO _reservaDAO;

        public AlugarCarroMensalController(CarroDAO carroDAO, ClienteDAO clienteDAO, ReservaDAO reservaDAO)
        {
            _carroDAO = carroDAO;
            _clienteDAO = clienteDAO;
            _reservaDAO = reservaDAO;
        }

        public IActionResult AluguelMensal(int id)
        {
            Id = id;
            var result = View(_carroDAO.GetId(id));
            return result;
        }

        [HttpPost]
        public IActionResult AluguelMensal(Carro carro, DateTime dtAluguel)
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");
            _reservaDAO.ReservaMensalCar(carro, dtAluguel, idCliente);
            return RedirectToAction("Index", "Cliente");
        }
    }
}