using Locadora.Models;
using Locadora.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.DAL
{
    public class ReservaDAO
    {
        private readonly Context _context;
        private readonly CarroDAO _carroDAO;
        private readonly MotoDAO _motoDAO;
        private readonly ClienteDAO _clienteDAO;

        public ReservaDAO(Context context, CarroDAO carroDAO, MotoDAO motoDAO, ClienteDAO clienteDAO)
        {
            _context = context;
            _carroDAO = carroDAO;
            _motoDAO = motoDAO;
            _clienteDAO = clienteDAO;
        }

        public List<Reserva> ListarReservasPendente() { return _context.Reservas.Where(x => x.Status.Equals("PENDENTE")).ToList(); }

        public Reserva Get(int id) { return _context.Reservas.Find(id); }

        public List<Reserva> ListarReservas() { return _context.Reservas.Include(i => i.Carro).Include(i => i.Moto).ToList(); }

        public void SaveReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public void ReservaMensalCar(Carro carro, DateTime dtAluguel, string idCliente)
        {
            carro = _carroDAO.GetId(carro.IdVeiculo);
            Reserva reserva = new Reserva();
            Cliente cliente = new Cliente();
            cliente = _clienteDAO.Get(Convert.ToInt32(idCliente));

            reserva.DataReserva = dtAluguel;

            DateTime dtAux;
            dtAux = dtAluguel;
            DateTime dtPrevisaoEntrega = dtAux.AddDays(30);

            reserva.ValorTotal = carro.ValorMensal;
            reserva.DataPrevisaoDevolucao = dtPrevisaoEntrega;
            ReservaDetailsCar(cliente, carro, reserva);
            SaveReserva(reserva);
        }

        public void ReservaDiariaCar(Carro carro, DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev, string idCliente, double txtValorTotReserva)
        {
            carro = _carroDAO.GetId(carro.IdVeiculo);
            Reserva reserva = new Reserva();
            Cliente cliente = new Cliente();
            cliente = _clienteDAO.Get(Convert.ToInt32(idCliente));

            reserva.DataReserva = Calculos.DataReplace(dtAluguel, txtHrAluguel);
            reserva.DataPrevisaoDevolucao = Calculos.DataReplace(dtDevolucaoPrev, txtHrReservaPrev);

            reserva.ValorTotalDiaria = txtValorTotReserva;
            ReservaDetailsCar(cliente, carro, reserva);
            SaveReserva(reserva);
        }

        public void ReservaDetailsCar(Cliente cliente, Carro carro, Reserva reserva)
        {
            cliente.CarroId = carro.IdVeiculo;
            cliente.PossuiReserva = "SIM";
            carro.Status = "RESERVADO";
            reserva.Carro = carro;
            reserva.Status = "PENDENTE";
            reserva.Cliente = cliente;
            reserva.CarroId = carro.IdVeiculo;
            reserva.ClienteId = cliente.IdCliente;
        }

        public void ReservaMensalMoto(Moto moto, DateTime dtAluguel, string idCliente)
        {
            moto = _motoDAO.GetId(moto.IdVeiculo);
            Reserva reserva = new Reserva();
            Cliente cliente = new Cliente();
            cliente = _clienteDAO.Get(Convert.ToInt32(idCliente));

            reserva.DataReserva = dtAluguel;

            DateTime dtAux;
            dtAux = dtAluguel;
            DateTime dtPrevisaoEntrega = dtAux.AddDays(30);

            reserva.ValorTotal = moto.ValorMensal;
            reserva.DataPrevisaoDevolucao = dtPrevisaoEntrega;
            ReservaDetailsMoto(cliente, moto, reserva);
            SaveReserva(reserva);
        }

        public void ReservaDetailsMoto(Cliente cliente, Moto moto, Reserva reserva)
        {
            cliente.MotoId = moto.IdVeiculo;
            cliente.PossuiReserva = "SIM";
            moto.Status = "RESERVADO";
            reserva.Moto = moto;
            reserva.Status = "PENDENTE";
            reserva.Cliente = cliente;
            reserva.MotoId = moto.IdVeiculo;
            reserva.ClienteId = cliente.IdCliente;
        }

        public void ReservaDiariaMoto(Moto moto, DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev, string idCliente, double txtValorTotReserva)
        {
            moto = _motoDAO.GetId(moto.IdVeiculo);
            Reserva reserva = new Reserva();
            Cliente cliente = new Cliente();
            cliente = _clienteDAO.Get(Convert.ToInt32(idCliente));

            reserva.DataReserva = Calculos.DataReplace(dtAluguel, txtHrAluguel);
            reserva.DataPrevisaoDevolucao = Calculos.DataReplace(dtDevolucaoPrev, txtHrReservaPrev);

            reserva.ValorTotalDiaria = txtValorTotReserva;
            ReservaDetailsMoto(cliente, moto, reserva);
            SaveReserva(reserva);
        }

        public void UpdateReserva(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            _context.SaveChanges();
        }



    }
}
