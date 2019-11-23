using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    [Table("RESERVA")]
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public DateTime? DataReserva { get; set; }
        public DateTime? DataPrevisaoDevolucao { get; set; }
        public DateTime? DataVeiculoDevolvido { get; set; }
        public decimal ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
        public Moto Moto { get; set; }
        public string Status { get; set; }
        public int? ClienteId { get; set; }
        public int? CarroId { get; set; }
        public int? MotoId { get; set; }
    }
}
