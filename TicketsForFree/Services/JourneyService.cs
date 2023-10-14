using TicketsForFree.Models;
using TicketsForFree.Data;
using TicketsForFree.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TicketsForFree.Services
{
    public class JourneyService : IJourneyService
    {

        private readonly TicketsDbContext _db;

        public JourneyService(TicketsDbContext dbContext)
        {
            _db = dbContext;
        }


        public async Task<Journey> AddJourney(Journey journey)
        {
            _db.Journeys.Add(journey);
            await _db.SaveChangesAsync();
            return journey;
        }

        public async Task<bool> DeleteJourney(int id)
        {
            var journey = await _db.Journeys.FindAsync(id);

            if (journey == null)
                return false;

            _db.Journeys.Remove(journey);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Journey?> Get(int id)
        {
            var journey = await _db.Journeys.FindAsync(id);
            if (journey != null)
            {
                return journey;

            }
            return null;
        }

        public async Task<IEnumerable<Journey>> GetAll()
        {
            var journeys = await _db.Journeys.ToListAsync();
            return journeys;
        }

        public async Task <IEnumerable<Journey>> GetJourneysByCity(string city)
        {
           var journeys =  await _db.Journeys.Where(j => j.DepartureCity == city || j.ArrivalCity == city).ToListAsync();
           return journeys;
        }

        public async  Task<IEnumerable<Journey>> GetJourneysByTransport(string transportType)
        {
            var journeys = await _db.Journeys.Where(j => j.Transport == transportType).ToListAsync();
            return journeys;
        }

        public async Task<Journey?> UpdateJourney(int id, Journey journey)
        {
            var jr = await _db.Journeys.FindAsync(id);
            if (jr is null)
                return null;

            jr.Transport = journey.Transport;
            jr.DepartureCity = journey.DepartureCity;
            jr.ArrivalCity = journey.ArrivalCity;
            jr.DepartureTime = journey.DepartureTime;
            jr.ArrivalTime = journey.ArrivalTime;
            jr.Price = journey.Price;
            jr.Capacity = journey.Capacity;

            await _db.SaveChangesAsync();

            return jr;
        }
    }
}
