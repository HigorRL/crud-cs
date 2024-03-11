using Microsoft.EntityFrameworkCore;
using CadastroClientesAPI.Models;


namespace CadastroClientesAPI.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
