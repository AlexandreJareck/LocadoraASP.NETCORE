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

        public IActionResult CartaoDebito(Reserva reserva, string txtHrAluguel, string nroCartaoDebito, string valorTotalPagamento, DateTime dtVeicDevolvido)
        {
            Reserva r = new Reserva();
            r = GetReserva();
            DateTime aux = DateTime.Now;

            if (string.IsNullOrWhiteSpace(nroCartaoDebito))
            {
                TempData["MsgCartaoDebito"] = "Preencha o número do cartão de débito";
                TempDataValores(txtHrAluguel, valorTotalPagamento, dtVeicDevolvido);
                return RedirectToAction("Pagamento");
            }

            aux = ValidaData(txtHrAluguel, dtVeicDevolvido, aux);

            reserva.DataVeiculoDevolvido = aux;
            _pagamentoDAO.PagamentoCartaoDebito(reserva, nroCartaoDebito, r, valorTotalPagamento);

            return RedirectToAction("Index", "Cliente");
        }

        public IActionResult CartaoCredito(Reserva reserva, string txtHrAluguel, string nroCartaoCredito, string valorTotalPagamento, DateTime dtVeicDevolvido)
        {
            Reserva r = new Reserva();
            r = GetReserva();
            DateTime aux = DateTime.Now;

            if (string.IsNullOrWhiteSpace(nroCartaoCredito))
            {
                TempData["MsgCartaoCredito"] = "Preencha o número do cartão de crédito";
                TempDataValores(txtHrAluguel, valorTotalPagamento, dtVeicDevolvido);
                return RedirectToAction("Pagamento");
            }

            aux = ValidaData(txtHrAluguel, dtVeicDevolvido, aux);

            reserva.DataVeiculoDevolvido = aux;
            _pagamentoDAO.PagamentoCartaoCredito(reserva, nroCartaoCredito, r, valorTotalPagamento);

            return RedirectToAction("Index", "Cliente");
        }

        public IActionResult Dinheiro(Reserva reserva, string txtHrAluguel, string dinheiro, string valorTotalPagamento, DateTime dtVeicDevolvido)
        {
            Reserva r = new Reserva();
            r = GetReserva();
            DateTime aux = DateTime.Now;
            if (!ValidarPagamento(txtHrAluguel, dinheiro, valorTotalPagamento, dtVeicDevolvido, aux))
            {
                return RedirectToAction("Pagamento");
            }

            if (Convert.ToDouble(dinheiro) < Convert.ToDouble(valorTotalPagamento))
            {
                double faltaParaPagar = Calculos.Pagamento(dinheiro, valorTotalPagamento);

                TempData["FaltaParaPagar"] = "Dinheiro insuficiente! Olhe o campo Valor total pagamento";
                TempDataValores(txtHrAluguel, faltaParaPagar.ToString(), dtVeicDevolvido);
                return RedirectToAction("Pagamento");
            }

            if (Convert.ToDouble(dinheiro) > Convert.ToDouble(valorTotalPagamento))
            {
                double result = Convert.ToDouble(dinheiro) - Convert.ToDouble(valorTotalPagamento);
                HttpContext.Session.SetString("MsgPagamentoOK", "Seu pagamento foi aceito. Seu troco é: " + result.ToString("C2") + "você ja pode alugar outro veiculo, obrigado!");
                reserva.DataVeiculoDevolvido = aux;
                _pagamentoDAO.PagamentoDinheiro(reserva, dinheiro, r, valorTotalPagamento, result);
                return RedirectToAction("Index", "Cliente");
            }
            if (Convert.ToDouble(dinheiro) == Convert.ToDouble(valorTotalPagamento))
            {
                HttpContext.Session.SetString("MsgPagamentoOK", "Seu pagamento foi aceito, você ja pode alugar outro veiculo, obrigado!");
                reserva.DataVeiculoDevolvido = aux;
                _pagamentoDAO.PagamentoDinheiro(reserva, dinheiro, r, valorTotalPagamento, 0);
                return RedirectToAction("Index", "Cliente");
            }
            return RedirectToAction("Pagamento");
        }

        public Reserva GetReserva()
        {
            var idCliente = HttpContext.Session.GetString("IdCliente");
            Reserva r = new Reserva();
            r = _reservaDAO.GetDevolucao(Convert.ToInt32(idCliente));
            return r;
        }

        public void TempDataValores(string txtHrAluguelVeic, string valorTotalPagamento, DateTime dtVeicDevolvido)
        {
            TempData["ValorTotal"] = valorTotalPagamento;
            TempData["hrAluguel"] = txtHrAluguelVeic;
            TempData["dtVeicDevolvido"] = dtVeicDevolvido;
        }

        public bool ValidarPagamento(string txtHrAluguelVeic, string dinheiro, string valorTotalPagamento, DateTime dtVeicDevolvido, DateTime aux)
        {
            if (string.IsNullOrWhiteSpace(dinheiro))
            {
                TempData["MsgDinheiro"] = "Preencha o valor do pagamento!";
                TempDataValores(txtHrAluguelVeic, valorTotalPagamento, dtVeicDevolvido);
                return false;
            }
            double pagamento = 0;
            try
            {
                pagamento = Convert.ToDouble(dinheiro);                
            }
            catch
            {
                TempData["NumeroNegativo"] = "Somente numeros positivos e inteiros!";
                return false;
            }
            aux = ValidaData(txtHrAluguelVeic, dtVeicDevolvido, aux);
            return true;
        }

        public DateTime ValidaData(string txtHrAluguelVeic, DateTime dtVeicDevolvido, DateTime aux)
        {
            if (txtHrAluguelVeic != null)
            {
                if (txtHrAluguelVeic != "0:00") { return Calculos.DataReplace(dtVeicDevolvido, txtHrAluguelVeic); }
                else { return dtVeicDevolvido; }
            }
            else { return dtVeicDevolvido; }
        }
    }
}