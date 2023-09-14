using Microsoft.EntityFrameworkCore;
using TP02_MVC.Models;

namespace TP02_MVC.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Bl> Bls { get; set; }

        public DbSet<Container> Containers { get; set; }
    }
}
