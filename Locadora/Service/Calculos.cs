using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Service
{
    public class Calculos
    {
        public static double DataReplace(DateTime dtAluguel, string txtHrAluguel, DateTime dtDevolucaoPrev, string txtHrReservaPrev, double valorTotalReserva, Carro carro)
        {

            int horaAluguel = Convert.ToInt32(txtHrAluguel.ToString().Replace(":00", ""));
            int horaDevolucao = Convert.ToInt32(txtHrReservaPrev.ToString().Replace(":00", ""));

            DateTime? dtAux;
            dtAux = dtAluguel;
            dtAluguel = Convert.ToDateTime(dtAux.Value.AddHours(horaAluguel));

            DateTime dtAux2;
            dtAux2 = dtDevolucaoPrev;
            dtDevolucaoPrev = dtAux2.AddHours(horaDevolucao);

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
    }
}
