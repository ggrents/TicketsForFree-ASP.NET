
using Microsoft.EntityFrameworkCore;
using TicketsForFree.Data;
using TicketsForFree.Models;
using TicketsForFree.Services.Interfaces;

namespace TicketsForFree.Services
{
    public class SeatService : ISeatService
    {

        private readonly TicketsDbContext _db;
        public SeatService(TicketsDbContext db)
        {

            _db = db;
        }

        public async Task<Seat> AddSeat(Seat seat)
        {
            _db.Seats.Add(seat);
            await _db.SaveChangesAsync();
            return seat;
        }

        public async Task<bool> DeleteSeat(int id)
        {

            var seat = await _db.Seats.FindAsync(id);

            if (seat == null)
                return false;

            _db.Seats.Remove(seat);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Seat>> GetAll()
        {
            var seats = await _db.Seats.ToListAsync();
            return seats;
        }

        public async Task<Seat> GetById(int id)
        {
            var seat = await _db.Seats.FindAsync(id);
            if (seat != null)
            {
                return seat;

            }
            return null;
        }

        public async Task<IEnumerable<Seat>> GetReservedSeats()
        {
            var seats = await _db.Seats.Where(seat => seat.IsReserved).ToListAsync();
            return seats;
        }

        public async Task<IEnumerable<Seat>> GetUnreservedSeats()
        {
            var seats = await _db.Seats.Where(seat => !seat.IsReserved).ToListAsync();
            return seats;
        }

        public async Task<IEnumerable<Seat>> GetVipSeats()
        {
            var seats = await _db.Seats.Where(seat => seat.IsVIP).ToListAsync();
            return seats;
        }

        
    }
}
