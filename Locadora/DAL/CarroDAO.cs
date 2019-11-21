using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.DAL
{
    public class CarroDAO
    {
        private readonly Context _context;

        #region Métodos de buscas e filtros

        public CarroDAO(Context context) { _context = context; }
        public List<Carro> ListarCarros() { return _context.Carros.ToList(); }
        public List<Carro> ListarCarrosDisponivel() { return _context.Carros.Where(x => x.Status.Equals("DISPONIVEL")).ToList(); }
        public List<Carro> ListarCarrosFake() { return _context.Carros.Where(x => x.Status.Equals("LISTAFAKE")).ToList(); }
        public Carro GetId(int id) { return _context.Carros.Find(id); }
        public Carro GetPlaca(Carro carro) { return _context.Carros.Where(x => x.Placa.Equals(carro.Placa)).FirstOrDefault(); }
        public List<Carro> ListCarPlaca(string placa) { return _context.Carros.Where(x => x.Placa.Equals(placa)).ToList(); }

        #endregion

        #region Crud

        public Carro CadastrarCarro(Carro carro)
        {
            if (GetPlaca(carro) != null)
            {
                carro = null;
                return carro;
            }
            Parameters(carro);
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return carro;
        }

        public void EditarCarro(Carro carro)
        {
            _context.Carros.Update(carro);
            _context.SaveChanges();
        }

        public void RemoverCarro(int id)
        {
            Carro carro = GetId(id);
            carro.Status = "CANCELADO";
            EditarCarro(carro);
        } 

        public void Parameters(Carro carro)
        {
            string precoVeiculo = carro.Valor.Replace("R$ ", "");
            carro.Preco = Convert.ToDecimal(precoVeiculo);
            carro.ValorMensal = (carro.Preco * 25)/100 ;
            carro.Status = "DISPONIVEL";
        }

        #endregion
    }
}
