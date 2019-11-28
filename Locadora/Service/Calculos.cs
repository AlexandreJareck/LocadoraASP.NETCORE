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
            if (aux2.Day <= aux1.Day &&
                aux2.Day <= aux1.Day &&
                aux2.DayOfYear <= aux1.DayOfYear)
            {
                return false;
            }

            return true;
        }

    }
}
