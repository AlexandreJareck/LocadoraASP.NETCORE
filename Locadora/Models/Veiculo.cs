using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        public Veiculo()
        {
            // Reserva = new List<Reserva>();
            // Devolucao = new List<Devolucao>();
        }
        [Key]
        public int IdVeiculo { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public double ValorPorDia { get; set; }
        public double ValorPorHora { get; set; }
        public string Status { get; set; }

        // public List<Reserva> Reserva { get; set; }
        // public List<Devolucao> Devolucao { get; set; }
    }
}
