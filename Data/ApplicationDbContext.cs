using CrudBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudBiblioteca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProductoViewModel> Productos { get; set; }
        public DbSet<ClienteViewModel> Clientes { get; set; }
        public DbSet<PedidoViewModel> Pedidos { get; set; }
    }
}
