using Microsoft.EntityFrameworkCore;
using MiniNext.Models;

namespace MiniNext.Context
{
    public class MiniFlixDatabaseContext : DbContext
    {

        public
        MiniFlixDatabaseContext(DbContextOptions<MiniFlixDatabaseContext> options)
        : base(options)
        {
        }

        public void addCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
            this.SaveChanges();
        }

        public void addPelicula(Pelicula pelicula)
        {
            Peliculas.Add(pelicula);
            this.SaveChanges();
        }

        public void addDocumental(Documental documental)
        {
            Documentales.Add(documental);
            this.SaveChanges();
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Documental> Documentales { get; set; }

    }
}