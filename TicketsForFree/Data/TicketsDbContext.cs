using Microsoft.EntityFrameworkCore;
using TicketsForFree.Models;

namespace TicketsForFree.Data
{
    public class TicketsDbContext : DbContext
    {

        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Reservation> Reservations  { get; set; }
        public DbSet<Seat> Seats  { get; set; }
        public DbSet<Voyage> Voyages  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TicketsForFreeDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }

    }
}
