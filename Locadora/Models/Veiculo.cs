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
        public string Ano_Modelo { get; set; }
        public string Marca { get; set; }
        public string Name { get; set; }
        public string veiculo { get; set; }
        public string Preco { get; set; }
        public string Combustivel { get; set; }
        public string Fipe_codigo { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public int IdentVeiculo { get; set; }
        public string Cor { get; set; }
        [Required(ErrorMessage = "Campos obrigatórios!")]
        public string Placa { get; set; }
        [Required]
        public double ValorPorDia { get; set; }
        [Required]
        public double ValorPorHora { get; set; }
        public string Status { get; set; }
        public string id { get; set; }

        // public List<Reserva> Reserva { get; set; }
        // public List<Devolucao> Devolucao { get; set; }
    }
}
