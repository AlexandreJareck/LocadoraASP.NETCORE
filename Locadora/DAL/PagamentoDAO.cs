using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.DAL
{
    public class PagamentoDAO
    {
        private readonly Context _context;
        private readonly CarroDAO _carroDAO;
        private readonly MotoDAO _motoDAO;
        private readonly ClienteDAO _clienteDAO;

        public PagamentoDAO(Context context, CarroDAO carroDAO, MotoDAO motoDAO, ClienteDAO clienteDAO)
        {
            _context = context;
            _motoDAO = motoDAO;
            _carroDAO = carroDAO;
            _clienteDAO = clienteDAO;
        }

        public void SalvarDevolucaoVeiculo(Reserva reserva, Pagamento pagamento)
        {

            reserva.Cliente.PossuiReserva = "NAO";
            reserva.Cliente.Status = "DISPONIVEL";
            pagamento.Status = "PAGO";
            pagamento.DtVeicDevolvido = (DateTime)reserva.DataVeiculoDevolvido;
            if (reserva.Carro == null) { reserva.Moto.Status = "DISPONIVEL"; }
            if (reserva.Moto == null) { reserva.Carro.Status = "DISPONIVEL"; }
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        public void PagamentoCartaoDebito(Reserva reserva, string nroCartaoDebito, Reserva r, string valorTotalPagamento)
        {
            Pagamento pagamento = DetailsSavePagamento(reserva, r, nroCartaoDebito, valorTotalPagamento, null);
            pagamento.Status = "PAGO NO DÉBITO";
            pagamento.Debito = true;
            reserva = DetailsReserva(reserva, r);

            SalvarDevolucaoVeiculo(reserva, pagamento);
        }

        public Reserva DetailsReserva(Reserva reserva, Reserva r)
        {
            if (r.CarroId == null)
            {
                reserva.MotoId = r.MotoId;
                reserva.Moto = _motoDAO.GetId(reserva.MotoId ?? 0);
            }
            else
            {
                reserva.CarroId = r.CarroId;
                reserva.Carro = _carroDAO.GetId(reserva.CarroId ?? 0);
            }
            reserva.IdReserva = r.IdReserva;
            reserva.DataPrevisaoDevolucao = r.DataPrevisaoDevolucao;
            reserva.DataReserva = r.DataReserva;
            reserva.ClienteId = r.ClienteId;
            reserva.Cliente = _clienteDAO.Get(r.ClienteId ?? 0);
            reserva.Status = "DEVOLVIDO";
            return reserva;
        }

        public void PagamentoCartaoCredito(Reserva reserva, string nroCartaoCredito, Reserva r, string valorTotalPagamento)
        {
            Pagamento pagamento = DetailsSavePagamento(reserva, r, nroCartaoCredito, valorTotalPagamento, null);
            pagamento.Status = "PAGO NO CRÉDITO";
            pagamento.Credito = true;

            reserva = DetailsReserva(reserva, r);

            SalvarDevolucaoVeiculo(reserva, pagamento);
        }

        public void PagamentoDinheiro(Reserva reserva, string dinheiro, Reserva r, string valorTotalPagamento, double result)
        {
            Pagamento pagamento = DetailsSavePagamento(reserva, r, null, valorTotalPagamento, dinheiro);
            pagamento.Status = "PAGO NO DINHEIRO";
            pagamento.Dinheiro = true;
            pagamento.ValorTroco = result;
            reserva = DetailsReserva(reserva, r);

            SalvarDevolucaoVeiculo(reserva, pagamento);
        }

        public void PagamentoDinheiro()
        {

        }

        public Pagamento DetailsSavePagamento(Reserva reserva, Reserva r, string nroCartao, string valorTotalPagamento, string dinheiro)
        {
            Pagamento pagamento = new Pagamento();

            if (nroCartao != null) pagamento.NroCartao = nroCartao;
            else pagamento.ValorPagamento = Convert.ToDouble(dinheiro);

            pagamento.Cliente = r.Cliente;
            pagamento.Reserva = reserva;
            pagamento.ValorTotalReserva = Convert.ToDouble(valorTotalPagamento);
            return pagamento;
        }
    }
}
