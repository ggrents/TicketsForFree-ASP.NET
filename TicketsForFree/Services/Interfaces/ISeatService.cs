using TicketsForFree.Models;

namespace TicketsForFree.Services.Interfaces
{
    public interface ISeatService
    {
   
        Task<IEnumerable<Seat>> GetAll();
        Task<IEnumerable<Seat>> GetVipSeats();
        Task<IEnumerable<Seat>> GetReservedSeats();
        Task<IEnumerable<Seat>> GetUnreservedSeats();
        Task<Seat> GetById(int id);
        Task<Seat> AddSeat(Seat seat);
        Task<bool> DeleteSeat(int id);
    }
}
