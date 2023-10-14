using TicketsForFree.Models;

namespace TicketsForFree.Services.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetSeatsByJourney(int journeyId);
        Task<IEnumerable<Seat>> GetAll();
        Task<IEnumerable<Seat>> GetVipSeats(int journeyId);
        Task<IEnumerable<Seat>> GetReservedSeats(int journeyId);
        Task<IEnumerable<Seat>> GetUnreservedSeats(int journeyId);
        Task<Seat> GetById(int id);
        Task<Seat> AddSeat(Seat seat);
        Task<Seat> UpdateSeat(Seat seat);
        Task<bool> DeleteSeat(int id);
    }
}
