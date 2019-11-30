using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        public Cliente()
        {
            Reserva = new List<Reserva>();
        }
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Cnh { get; set; }
        public string CategoriaCnh { get; set; }
        public List<Reserva> Reserva { get; set; }
        public string PossuiReserva { get; set; }
        public string Status { get; set; }
        public int? Ident { get; set; }
        public int? MotoId { get; set; }
        public int? CarroId { get; set; }        
    }
}
