using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.DAL;
using Locadora.Models;
using Locadora.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers.ClienteCtrl
{
    public class DevolucaoController : Controller
    {
        private readonly ReservaDAO _reservaDAO;
        private readonly PagamentoDAO _pagamentoDAO;

        public DevolucaoController(ReservaDAO reservaDAO, PagamentoDAO pagamentoDAO)
        {
            _reservaDAO = reservaDAO;
            _pagamentoDAO = pagamentoDAO;
        }

        public IActionResult Pagamento()
        {
            Reserva r = GetReserva();

            if (TempData["dtVeicDevolvido"] != null) { ViewBag.dtVeicDevolvido = TempData["dtVeicDevolvido"]; }

            if (r != null)
            {
                if (r.Cliente.PossuiReserva.Equals("NAO"))
                {
                    ModelState.AddModelError("", "Você não possui uma reserva!");
                    return View();
                }
                DateTime aux = (DateTime)r.DataReserva;
                TempData["hrAluguelVeic"] = aux.Hour.ToString() + ":00";
                DateTime aux2 = (DateTime)r.DataPrevisaoDevolucao;
                TempData["hrPrevVeic"] = aux2.Hour.ToString() + ":00";
                return View(r);
            }

            ModelState.AddModelError("", "Você não possui uma reserva!");
            return View();
        }

        public IActionResult CalcularPagamento(Reserva reserva, string txtHrAluguel)
        {
            Reserva r = GetReserva();
            DateTime aux;
            TempData["hrAluguel"] = txtHrAluguel;
            if (txtHrAluguel != null)
                aux = Calculos.DataReplace((DateTime)reserva.DataVeiculoDevolvido, txtHrAluguel);
            else
                aux = (DateTime)reserva.DataVeiculoDevolvido;

            if (!Calculos.DateValidationDevolucao((DateTime)r.DataPrevisaoDevolucao, aux))
            {
                TempData["Msg"] = "Data de reserva não pode ser menor que a data de devolução!";
                return RedirectToAction("Pagamento");
            }
            TempData["ValorTotal"] = Calculos.DefineReservaDiariaOuMensal(reserva, aux);
            TempData["dtVeicDevolvido"] = (DateTime)reserva.DataVeiculoDevolvido;

            return RedirectToAction("Pagamento");
        }

        public IActionResult CartaoDebito(Reserva reserva, string txtHrAluguelVeic, string nroCartaoDebito, string valorTotalPagamento, DateTime dtVeicDevolvido)
        {
            Reserva r = new Reserva();
            r = GetReserva();
            DateTime aux;
            if (string.IsNullOrWhiteSpace(nroCartaoDebito))
            {
                TempData["MsgCartaoDebito"] = "Preencha o número do cartão de débito";
                return RedirectToAction("Pagamento");
            }

            if (txtHrAluguelVeic != "0:00")
                aux = Calculos.DataReplace(dtVeicDevolvido, txtHrAluguelVeic);
            else
                aux = dtVeicDevolvido;
            reserva.DataVeiculoDevolvido = aux;
            _pagamentoDAO.PagamentoCartaoDebito(reserva, nroCartaoDebito, r, valorTotalPagamento);

            return RedirectToAction("Index", "Cliente");
        }

        public IActionResult CartaoCredito(Reserva reserva, string txtHrAluguelVeic, string nroCartaoCredito, string valorTotalPagamento, DateTime dtVeicDevolvido)
        {
            Reserva r = new Reserva();
            r = GetReserva();
            DateTime aux;
            if (string.IsNullOrWhiteSpace(nroCartaoCredito))
            {
                TempData["MsgCartaoCredito"] = "Preencha o número do cartão de crédito";
                return RedirectToAction("Pagamento");
            }
            if (txtHrAluguelVeic != "0:00")
                aux = Calculos.DataReplace(dtVeicDevolvido, txtHrAluguelVeic);
            else
                aux = dtVeicDevolvido;

            reserva.DataVeiculoDevolvido = aux;
            _pagamentoDAO.PagamentoCartaoCredito(reserva, nroCartaoCredito, r, valorTotalPagamento);

            return RedirectToAction("Index", "Cliente");
        }

        public IActionResult Dinheiro(Reserva reserva, string txtHrAluguelVeic, string dinheiro, string valorTotalPagamento, DateTime dtVeicDevolvido)
        {
            Reserva r = new Reserva();
            r = GetReserva();
            DateTime aux;
            if (string.IsNullOrWhiteSpace(dinheiro))
            {
                TempData["MsgDinheiro"] = "Preencha o valor do pagamento!";
                return RedirectToAction("Pagamento");
            }
            
            if (txtHrAluguelVeic != "0:00")
                aux = Calculos.DataReplace(dtVeicDevolvido, txtHrAluguelVeic);
            else
                aux = dtVeicDevolvido;

            reserva.DataVeiculoDevolvido = aux;
            _pagamentoDAO.PagamentoCartaoCredito(reserva, dinheiro, r, valorTotalPagamento);
            return RedirectToAction("Index", "Cliente");
        }

        public Reserva GetReserva()
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");            
            Reserva r = new Reserva();
            r = _reservaDAO.GetDevolucao(Convert.ToInt32(idCliente));
            return r;
        }
    }
}