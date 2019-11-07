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
        public int Id { get; set; }
        public int Ano_Modelo { get; set; }
        public string Marca { get; set; }
        public string Name { get; set; }
        public string veiculo { get; set; }
        public double Preco { get; set; }
        public string Combustivel { get; set; }
        public string Fipe_codigo { get; set; }
      
       /// ////////////////////////////////////////
      
        public string Cor { get; set; }       
        public string Placa { get; set; }
        public double ValorPorDia { get; set; }
        public double ValorPorHora { get; set; }
        public string Status { get; set; }

        // public List<Reserva> Reserva { get; set; }
        // public List<Devolucao> Devolucao { get; set; }
    }
}
