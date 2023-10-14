using TicketsForFree.Models;

namespace TicketsForFree.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAll();
        Task<IEnumerable<Reservation>> GetReservationsForUser(int userId);
        Task<IEnumerable<Reservation>> GetReservationsForJourney(int JourneyId);
        Task<Reservation?> GetReservationById(int reservationId);
        Task<Reservation> MakeReservation(Reservation reservation);
        Task<bool> RemoveReservation(int reservationId);

    }
}
