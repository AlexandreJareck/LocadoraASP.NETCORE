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

        #region Métodos de busca e filtros

        public MotoDAO(Context context) { _context = context; }
        public List<Moto> ListarMotos() { return _context.Motos.ToList(); }
        public List<Moto> ListarMotosDisponivel() { return _context.Motos.Where(x => x.Status.Equals("DISPONIVEL")).ToList(); }
        public List<Moto> ListarMotosFake() { return _context.Motos.Where(x => x.Status.Equals("LISTAFAKE")).ToList(); }
        public Moto GetId(int id) { return _context.Motos.Find(id); }
        public Moto GetPlaca(Moto moto) { return _context.Motos.Where(x => x.Placa.Equals(moto.Placa)).FirstOrDefault(); }
        public List<Moto> ListMotoPlaca(string placa) { return _context.Motos.Where(x => x.Placa.Equals(placa)).ToList(); }

        #endregion

        #region Crud

        public Moto CadastrarMoto(Moto moto)
        {
            if (GetPlaca(moto) != null)
            {
                moto = null;
                return moto;
            }
            Parameters(moto);
            _context.Motos.Add(moto);
            _context.SaveChanges();
            return moto;
        }

        public void EditarMoto(Moto moto)
        {
            _context.Motos.Update(moto);
            _context.SaveChanges();
        }

        public void RemoverMoto(int id)
        {
            Moto moto = GetId(id);
            moto.Status = "CANCELADO";
            EditarMoto(moto);
        }

        public void Parameters(Moto moto)
        {
            string precoVeiculo = moto.Valor.Replace("R$ ", "");
            moto.Preco = Convert.ToDecimal(precoVeiculo);
            moto.ValorMensal = (moto.Preco * 25) / 100;
            moto.Status = "DISPONIVEL";
            moto.Nome = moto.Modelo;
            moto.IdMarca = null;
            moto.CodigoFipe = null;
            moto.IdModelo = null;
            moto.IdentVeiculo = null;
        }

        #endregion
    }
}
