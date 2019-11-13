using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.DAL
{
    public class MotoDAO
    {
        private readonly Context _context;
        public MotoDAO(Context context)
        {
            _context = context;
        }

        public List<Moto> ListarMotos()
        {
            return _context.Motos.ToList();
        }
        public List<Moto> ListarMotosDs()
        {
            return _context.Motos.Where(x => x.Status.Equals("DISPONIVEL")).ToList();
        }

        public Moto Get(int id)
        {
            return _context.Motos.Find(id);
        }

        public Moto CadastrarMoto(Moto moto)
        {
            if (Get(moto) != null)
            {
                moto = null;
                return moto;
            }
            moto.Status = "DISPONIVEL";
            _context.Motos.Add(moto);
            _context.SaveChanges();
            return moto;
        }

        public Moto Get(Moto moto)
        {
            var result = _context.Motos.Where(x => x.Placa.Equals(moto.Placa)).FirstOrDefault();

            return result;
        }

       public void EditarMoto(Moto moto)
        {
            //moto.IdVeiculo = Convert.ToInt32(moto.id);
            _context.Motos.Update(moto);
            _context.SaveChanges();
        }  

        public void RemoverMoto(int id)
        {
            Moto moto = Get(id);
            moto.Status = "CANCELADO";
            EditarMoto(moto);
        }

    }
}
