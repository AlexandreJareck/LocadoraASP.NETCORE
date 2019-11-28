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
    public class AlugarMotoDiariaController : Controller
    {
        public static int Id;

        private readonly MotoDAO _motoDAO;
        private readonly ClienteDAO _clienteDAO;
        private readonly ReservaDAO _reservaDAO;

        public AlugarMotoDiariaController(MotoDAO motoDAO, ClienteDAO clienteDAO, ReservaDAO reservaDAO)
        {
            _motoDAO = motoDAO;
            _clienteDAO = clienteDAO;
            _reservaDAO = reservaDAO;
        }

        public IActionResult AluguelDiaria(int id)
        {
            Id = id;
            if (TempData["dtAluguel"] != null)
            {
                ViewBag.DataAluguel = TempData["dtAluguel"];
            }
            if (TempData["dtDevolucaoPrev"] != null)
            {
                ViewBag.DataDevolucaoPrev = TempData["dtDevolucaoPrev"];
            }
            var result = View(_motoDAO.GetId(id));
            return result;
        }

        [HttpPost]
        public IActionResult CalcularValorDaReserva(Moto moto, DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev)
        {

            if(!Calculos.DateValidationReservaDiaria(dtAluguel, txtHrAluguel, dtDevolucaoPrev, txtHrReservaPrev))
            {
                TempData["Msg"] = "Data de reserva não pode ser menor que a data de devolução!";
                return RedirectToAction("AluguelDiaria", new { id = moto.IdVeiculo });
            }
            double valorTotalReserva = 0;
            valorTotalReserva = Calculos.DataReplaceCalc(dtAluguel, txtHrAluguel, dtDevolucaoPrev, txtHrReservaPrev, valorTotalReserva, moto);

            TempData["valorTotReserva"] = valorTotalReserva;
            TempData["hrAluguel"] = txtHrAluguel;
            TempData["dtAluguel"] = (DateTime)dtAluguel;
            TempData["dtDevolucaoPrev"] = (DateTime)dtDevolucaoPrev;
            TempData["hrReservaPrev"] = txtHrReservaPrev;
            return RedirectToAction("AluguelDiaria", new { id = moto.IdVeiculo });
        }
        [HttpPost]
        public IActionResult AluguelDiaria(Moto moto, DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev, double txtValorTotReserva)
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");

            _reservaDAO.ReservaDiariaMoto(moto, dtAluguel, txtHrAluguel, dtDevolucaoPrev, txtHrReservaPrev, idCliente, txtValorTotReserva);

            return RedirectToAction("Index", "Cliente");
        }
    }
}