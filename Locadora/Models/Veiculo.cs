using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        [Key]
        public int IdVeiculo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; }
        public int TipoVeiculo { get; set; }
        public string IdMarca { get; set; }
        public string IdModelo { get; set; }
        public string CodigoFipe { get; set; }
        public string IdentVeiculo { get; set; }
        public string Cor { get; set; }
        [Required(ErrorMessage = "Campos obrigatórios!")]
        public string Placa { get; set; }
        [Required]
        public double ValorPorDia { get; set; }
        [Required]
        public double ValorPorHora { get; set; }
        public string Status { get; set; }        
        public string Imagem { get; set; }
        public decimal ValorMensal { get; set; }
        public decimal Preco { get; set; }
        public List<Modelo> Modelos { get; set; } = new List<Modelo>();
    }

    public class Modelo
    {
        [Key]
        public int ModeloId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }

}
