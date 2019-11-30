using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ReservaDAO _reservaDAO;

        public AdministradorController(ReservaDAO reservaDAO)
        {
            _reservaDAO = reservaDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AprovarReserva()
        {
            return View(_reservaDAO.ListarReservasPendente());
        }
        
        public IActionResult ConfirmReserva(int id)
        {
            Reserva reserva = new Reserva();
            reserva = _reservaDAO.Get(id);
            reserva.Cliente.Ident = reserva.IdReserva;
            reserva.Cliente.Status = "PENDENTE";
            reserva.Status = "APROVADO";    
            
            _reservaDAO.UpdateReserva(reserva);
            return RedirectToAction("AprovarReserva");
        }

        public IActionResult CancelReserva(int id)
        {
            Reserva reserva = new Reserva();
            reserva = _reservaDAO.Get(id);
            reserva.Status = "CANCELADA";
            reserva.Cliente.Ident = reserva.IdReserva;
            _reservaDAO.UpdateReserva(reserva);
            return RedirectToAction("AprovarReserva");
        }

        public IActionResult ReservasHistorico()
        {
            return View(_reservaDAO.ListarReservas());
        }

    }
}