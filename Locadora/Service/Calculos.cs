using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Service
{
    public class Calculos
    {
        public static double DataReplaceCalc(DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev, double valorTotalReserva, Carro carro)
        {

            dtAluguel = DataReplace(dtAluguel, txtHrAluguel);
            dtDevolucaoPrev = DataReplace(dtDevolucaoPrev, txtHrReservaPrev);

            valorTotalReserva = CalculaValorReserva(dtAluguel, dtDevolucaoPrev, valorTotalReserva, carro);

            return valorTotalReserva;
        }

        public static double CalculaValorReserva(DateTime dtAluguel, DateTime dtDevolucaoPrev, double valorTotalReserva, Carro carro)
        {
            TimeSpan duration = dtAluguel.Subtract(dtDevolucaoPrev);

            if (duration.Hours < 0 || duration.Days < 0)
            {
                duration = dtDevolucaoPrev.Subtract(dtAluguel);
            }

            if (duration.TotalHours <= 12.0)
            {
                return valorTotalReserva = carro.ValorPorHora * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                return valorTotalReserva = carro.ValorPorDia * Math.Ceiling(duration.TotalDays);
            }
        }

        public static double DataReplaceCalc(DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev, double valorTotalReserva, Moto moto)
        {
            dtAluguel = DataReplace(dtAluguel, txtHrAluguel);
            dtDevolucaoPrev = DataReplace(dtDevolucaoPrev, txtHrReservaPrev);

            valorTotalReserva = CalculaValorReservaMoto(dtAluguel, dtDevolucaoPrev, valorTotalReserva, moto);

            return valorTotalReserva;
        }

        public static double CalculaValorReservaMoto(DateTime dtAluguel, DateTime dtDevolucaoPrev, double valorTotalReserva, Moto moto)
        {
            TimeSpan duration = dtAluguel.Subtract(dtDevolucaoPrev);

            if (duration.Hours < 0 || duration.Days < 0)
            {
                duration = dtDevolucaoPrev.Subtract(dtAluguel);
            }

            if (duration.TotalHours <= 12.0)
            {
                return valorTotalReserva = moto.ValorPorHora * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                return valorTotalReserva = moto.ValorPorDia * Math.Ceiling(duration.TotalDays);
            }
        }

        public static DateTime DataReplace(DateTime data, string hora)
        {
            int horaAluguel = Convert.ToInt32(hora.ToString().Replace(":00", ""));
            DateTime? dtAux;
            dtAux = data;
            return Convert.ToDateTime(dtAux.Value.AddHours(horaAluguel));
        }

        public static bool DateValidationReservaDiaria(DateTime data, string hora, DateTime data2, string hora2)
        {
            DateTime aux1 = DataReplace(data, hora);
            DateTime aux2 = DataReplace(data2, hora2);
            if (aux2.Day <= aux1.Day && aux2.DayOfYear <= aux1.DayOfYear)
                return false;
            else
                return true;
        }

        public static double DefineReservaDiariaOuMensal(Reserva reserva, DateTime data)
        {
            if (reserva.ValorTotal == 0)
                return CalcularValorDevolucaoDiaria(reserva, data);
            else
                return CalcularValorDevolucaoMensal(reserva, data);
        }

        public static double CalcularValorDevolucaoDiaria(Reserva reserva, DateTime devolvidoEm)
        {

            TimeSpan duration = devolvidoEm.Subtract((DateTime)reserva.DataPrevisaoDevolucao);

            if (duration.TotalHours > 0.5 && duration.TotalHours <= 12.0)
            {
                double valorTotalPagamento = (reserva.ValorTotalDiaria * 0.20) + reserva.ValorTotalDiaria;
                return valorTotalPagamento;

            }
            else
            {
                double valorTotalPagamento = (reserva.ValorTotalDiaria * 0.50) + reserva.ValorTotalDiaria;
                return valorTotalPagamento;
            }
        }

        public static double CalcularValorDevolucaoMensal(Reserva reserva, DateTime devolvidoEm)
        {

            TimeSpan duration = devolvidoEm.Subtract((DateTime)reserva.DataPrevisaoDevolucao);

            if (duration.TotalHours > 0.5 && duration.TotalHours <= 12.0)
            {
                double valorTotalPagamento = ((double)reserva.ValorTotal * 0.20) + (double)reserva.ValorTotal;
                return valorTotalPagamento;

            }
            else
            {
                double valorTotalPagamento = ((double)reserva.ValorTotal * 0.50) + (double)reserva.ValorTotal;
                return valorTotalPagamento;
            }
        }

        public static bool DateValidationDevolucao(DateTime dtPrevisao, DateTime dtDevolvidoEm)
        {

            if (dtDevolvidoEm.Year < dtPrevisao.Year)
            {
                return false;
            }
            if (dtDevolvidoEm.DayOfYear < dtPrevisao.DayOfYear)
            {
                return false;
            }
            if (dtDevolvidoEm.DayOfYear == dtPrevisao.DayOfYear)
            {
                if (dtDevolvidoEm.Hour < dtPrevisao.Hour)
                {
                    return false;
                }
            }

            return true;
        }

        public static double Pagamento(string dinheiro, string valorTotalPagamento)
        {
            double money = Convert.ToDouble(dinheiro);
            double total = Convert.ToDouble(valorTotalPagamento);
            double result = 0;
            if (money < total)
            {
                result = total - money;
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
