using Microsoft.EntityFrameworkCore;
using TicketsForFree.Data;
using TicketsForFree.Models;
using TicketsForFree.Services.Interfaces;
namespace TicketsForFree.Services
{
    public class ReservationService : IReservationService
    {

        private readonly TicketsDbContext _db;
        public ReservationService(TicketsDbContext db)
        {

            _db = db;
        }

        public async Task<bool> RemoveReservation(int reservationId)
        {
            var reservation = await _db.Reservations.FindAsync(reservationId);

            if (reservation == null)
                return false;

            _db.Reservations.Remove(reservation);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            var reservs = await _db.Reservations.Include(r => r.User).Include(r => r.Journey).Include(r => r.Seat).ToListAsync(); 
            return reservs;
            
        }

        public async Task<Reservation?> GetReservationById(int reservationId)
        {
            return await _db.Reservations
            .Where(r => r.ReservationId == reservationId)
            .Include(r => r.User)
            .Include(r => r.Journey)
            .Include(r => r.Seat)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsForUser(int userId)
        {
            return await _db.Reservations
            .Where(r => r.UserId == userId)
            .Include(r => r.User)
            .Include(r => r.Journey)
            .Include(r => r.Seat)
            .ToListAsync();
        }

        public async Task<Reservation> MakeReservation(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
            return reservation; 
        }

        public async Task<IEnumerable<Reservation>> GetReservationsForJourney(int journeyId)
        {
            return await _db.Reservations
            .Where(r => r.UserId == journeyId)
            .Include(r => r.User)
            .Include(r => r.Journey)
            .Include(r => r.Seat)
            .ToListAsync();
        }
    }
}
