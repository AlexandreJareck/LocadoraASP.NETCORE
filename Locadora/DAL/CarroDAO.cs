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
        public List<Carro> ListarCarrosDs() { return _context.Carros.Where(x => x.Status.Equals("DISPONIVEL")).ToList(); }
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
            carro.Status = "DISPONIVEL";
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

        #endregion
    }
}
