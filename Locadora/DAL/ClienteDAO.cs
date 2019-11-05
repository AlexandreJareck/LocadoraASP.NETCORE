using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.DAL
{
    public class ClienteDAO
    {

        private readonly Context _context;

        public ClienteDAO(Context context)
        {
            _context = context;
        }

        public List<Cliente> ListarClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente Get(int id)
        {
            return _context.Clientes.Find(id);
        }

        public Cliente CadastrarCliente(Cliente cliente)
        {
            if (Get(cliente) != null)
            {
                cliente = null;
                return cliente;
            }
            cliente.PossuiReserva = "NAO";
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente Get(Cliente cliente)
        {
            var result = _context.Clientes.Where(x => x.Cpf.Equals(cliente.Cpf)).FirstOrDefault();

            return result;
        }

        public bool AutenticarLogin(string cpf, string senha)
        {
            var result = _context.Clientes.FirstOrDefault(x => x.Cpf.Equals(cpf) && x.Senha.Equals(senha));
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public void EditarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void RemoverCliente(int id)
        {
            Cliente cliente = Get(id);
            cliente.Status = "CANCELADO";
            EditarCliente(cliente);
        }
    }
}

