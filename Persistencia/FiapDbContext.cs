using Checkpoint2DotNet_Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint2DotNet_Biblioteca.Persistencia
{
    public class FiapDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Biblioteca> Bibliotecas { get; set; }


        public FiapDbContext(DbContextOptions<FiapDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}
