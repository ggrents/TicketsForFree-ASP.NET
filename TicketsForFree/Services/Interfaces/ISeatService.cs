using TicketsForFree.Models;

namespace TicketsForFree.Services.Interfaces
{
    public interface ISeatService
    {
<<<<<<< HEAD
   
        Task<IEnumerable<Seat>> GetAll();
        Task<IEnumerable<Seat>> GetVipSeats();
        Task<IEnumerable<Seat>> GetReservedSeats();
        Task<IEnumerable<Seat>> GetUnreservedSeats();
        Task<Seat> GetById(int id);
        Task<Seat> AddSeat(Seat seat);
=======
        Task<IEnumerable<Seat>> GetSeatsByJourney(int journeyId);
        Task<IEnumerable<Seat>> GetAll();
        Task<IEnumerable<Seat>> GetVipSeats(int journeyId);
        Task<IEnumerable<Seat>> GetReservedSeats(int journeyId);
        Task<IEnumerable<Seat>> GetUnreservedSeats(int journeyId);
        Task<Seat> GetById(int id);
        Task<Seat> AddSeat(Seat seat);
        Task<Seat> UpdateSeat(Seat seat);
>>>>>>> cb32489a51433bf8958d45d859864c9408c31f75
        Task<bool> DeleteSeat(int id);
    }
}
