using TicketsForFree.Models;

namespace TicketsForFree.Services.Interfaces
{
    public interface IJourneyService
    {

        public Task<IEnumerable<Journey>> GetAll();

        public Task<IEnumerable<Journey>> GetJourneysByCity(string city);
        public Task<IEnumerable<Journey>> GetJourneysByTransport(string transportType);
        public Task<Journey?> Get(int id);
        public Task<Journey> AddJourney(Journey journey);
        public Task<Journey?> UpdateJourney(int id, Journey journey);
        public Task<bool> DeleteJourney(int id);

    }
}
