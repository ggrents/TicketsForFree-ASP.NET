using Microsoft.EntityFrameworkCore;
using TicketsForFree.Models;

namespace TicketsForFree.Data
{
    public class TicketsDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Reservation> Reservations  { get; set; }

    }
}
