using Microsoft.EntityFrameworkCore;
using ReservaCabanasApp.Models;

namespace ReservaCabanasApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cabana> Cabanas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}