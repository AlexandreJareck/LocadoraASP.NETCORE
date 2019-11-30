using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Context : IdentityDbContext<ClienteLogado>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
