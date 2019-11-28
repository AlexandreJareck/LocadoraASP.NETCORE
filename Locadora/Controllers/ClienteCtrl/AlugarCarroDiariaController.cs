using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Locadora.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers.ClienteCtrl
{
    [Authorize]
    public class AlugarCarroDiariaController : Controller
    {
        public static int Id;

        private readonly CarroDAO _carroDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly ReservaDAO _reservaDAO;

        public AlugarCarroDiariaController(CarroDAO carroDAO, ClienteDAO clienteDAO, ReservaDAO reservaDAO)
        {
            _carroDAO = carroDAO;
            _clienteDAO = clienteDAO;
            _reservaDAO = reservaDAO;
        }

        public IActionResult AluguelDiaria(int id)
        {
            Id = id;
            if(TempData["dtAluguel"] != null)
            {
                ViewBag.DataAluguel = TempData["dtAluguel"];
            }
            if(TempData["dtDevolucaoPrev"] != null)
            {
                ViewBag.DataDevolucaoPrev = TempData["dtDevolucaoPrev"];
            }
            var result = View(_carroDAO.GetId(id));
            return result;
        }

        [HttpPost]
        public IActionResult CalcularValorDaReserva(Carro carro, DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev)
        {
            double valorTotalReserva = 0;

            valorTotalReserva = Calculos.DataReplaceCalc(dtAluguel, txtHrAluguel, dtDevolucaoPrev, txtHrReservaPrev, valorTotalReserva, carro); ;

            TempData["valorTotReserva"] = valorTotalReserva;
            TempData["hrAluguel"] = txtHrAluguel;
            TempData["dtAluguel"] = (DateTime)dtAluguel;
            TempData["dtDevolucaoPrev"] = (DateTime) dtDevolucaoPrev;
            TempData["hrReservaPrev"] = txtHrReservaPrev;
            return RedirectToAction("AluguelDiaria", new { id = carro.IdVeiculo});
        }
        [HttpPost]
        public IActionResult AluguelDiaria(Carro carro, DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev, double txtValorTotReserva)
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");

            _reservaDAO.ReservaDiariaCar(carro, dtAluguel, txtHrAluguel, dtDevolucaoPrev, txtHrReservaPrev, idCliente, txtValorTotReserva);

            return RedirectToAction("Index", "Cliente");
        }
    }
}