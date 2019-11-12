using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.DAL
{
    public class CarroDAO
    {
        private readonly Context _context;

        public CarroDAO(Context context)
        {
            _context = context;
        }

        public List<Carro> ListarCarros()
        {
            return _context.Carros.ToList();
        }

        public Carro Get(int id)
        {
            return _context.Carros.Find(id);
        }

        public Carro CadastrarCarro(Carro carro)
        {
            if (Get(carro) != null)
            {
                carro = null;
                return carro;
            }
            carro.Status = "DISPONIVEL";
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return carro;
        }

        public Carro Get(Carro carro)
        {
            var result = _context.Carros.Where(x => x.Placa.Equals(carro.Placa)).FirstOrDefault();

            return result;
        }

        public void EditarCarro(Carro carro)
        {
            carro.IdVeiculo = Convert.ToInt32(carro.id);
            _context.Carros.Update(carro);
            _context.SaveChanges();
        }

        public void RemoverCarro(int id)
        {
            Carro carro = Get(id);
            carro.Status = "CANCELADO";
            EditarCarro(carro);
        }
    }
}
