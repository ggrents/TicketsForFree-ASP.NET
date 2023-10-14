using Microsoft.AspNetCore.Mvc;
using TicketsForFree.Models;
using TicketsForFree.Services;
using TicketsForFree.Services.Interfaces;
using TicketsForFree.ViewModels;

namespace TicketsForFree.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class JourneysController : ControllerBase
    {


        private readonly IJourneyService _journeyService;

        public JourneysController(IJourneyService JourneyService)
        {
            _journeyService = JourneyService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journey>>> GetAll()
        {

            var journeys = await _journeyService.GetAll();
            return Ok(journeys);
        }


        [HttpGet("city/{city}")]
        public async Task<ActionResult<IEnumerable<Journey>>> GetByCity(string city)
        {

            var journeys = await _journeyService.GetJourneysByCity(city);
            return Ok(journeys);
        }

        [HttpGet("transport/{type}")]
        public async Task<ActionResult<IEnumerable<Journey>>> GetByTransport(string type)
        {

            var journeys = await _journeyService.GetJourneysByTransport(type);
            return Ok(journeys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Journey>> GetJourneyById(int id)
        {
            var journey = await _journeyService.Get(id);

            if (journey == null)
                return NotFound();

            return Ok(journey);
        }


        [HttpDelete]
        [Route("{id}")]
          public async Task<ActionResult> DeleteJourney(int id)
        {
            await _journeyService.DeleteJourney(id);
            var journeys = await _journeyService.GetAll();
            return Ok(journeys);
        }



        [HttpPost]
        public async Task<IActionResult> AddJourney([FromBody] CreateUpdateJourneyViewModel newJourney)
        {
            try
            {
              
                var UserToCreate = new Journey
                {

                    Transport = newJourney.Transport,
                    DepartureCity = newJourney.DepartureCity,
                    ArrivalCity = newJourney.ArrivalCity,
                    DepartureTime = newJourney.DepartureTime,
                    ArrivalTime = newJourney.ArrivalTime,
                    Price = newJourney.Price,
                    Capacity = newJourney.Capacity

                };

                var createdJourney = await _journeyService.AddJourney(UserToCreate);

                return Ok(createdJourney);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Failed to create journey", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJourney(int id, [FromBody] CreateUpdateJourneyViewModel updatedJourney)
        {
            try
            {
                if (updatedJourney == null)
                {
                    return BadRequest(new { message = "Journey data is invalid" });
                }


                var existingJourney = await _journeyService.Get(id);

                if (existingJourney == null)
                {
                    return NotFound(new { message = "Journey not found" });
                }


                existingJourney.Transport = updatedJourney.Transport;
                existingJourney.DepartureCity = updatedJourney.DepartureCity;
                existingJourney.ArrivalCity = updatedJourney.ArrivalCity;
                existingJourney.DepartureTime = updatedJourney.DepartureTime;
                existingJourney.ArrivalTime = updatedJourney.ArrivalTime;
                existingJourney.Price = updatedJourney.Price;
                existingJourney.Capacity = updatedJourney.Capacity;




                var JourneyToUpdate = await _journeyService.UpdateJourney(id, existingJourney);

                return Ok(JourneyToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to update journey", error = ex.Message });
            }



        }


        [HttpPatch("{id}")]

        public async Task<ActionResult> PartUpdateUser(int id, [FromBody] CreateUpdateJourneyViewModel updatedJourney)
        {
            try
            {
                if (updatedJourney == null)
                {
                    return BadRequest(new { message = "Journey data is invalid" });
                }


                var existingJourney = await _journeyService.Get(id);

                if (existingJourney == null)
                {
                    return NotFound(new { message = "Journey not found" });
                }


                if (updatedJourney.Transport != null)
                {
                    existingJourney.Transport = updatedJourney.Transport;
                }

                if (updatedJourney.DepartureCity != null)
                {
                    existingJourney.DepartureCity = updatedJourney.DepartureCity;
                }

                if (updatedJourney.ArrivalCity != null)
                {
                    existingJourney.ArrivalCity = updatedJourney.ArrivalCity;
                }

                if (updatedJourney.DepartureTime != DateTime.MinValue)
                {
                    existingJourney.DepartureTime = updatedJourney.DepartureTime;
                }

                if (updatedJourney.ArrivalTime != DateTime.MinValue)
                {
                    existingJourney.ArrivalTime = updatedJourney.ArrivalTime;
                }

                if (updatedJourney.Price != 0)
                {
                    existingJourney.Price = updatedJourney.Price;
                }

                if (updatedJourney.Capacity != 0)
                {
                    existingJourney.Capacity = updatedJourney.Capacity;
                }




                var JourneyToUpdate = await _journeyService.UpdateJourney(id, existingJourney);

                var jr = await _journeyService.Get(id);

                return Ok(jr);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to update journey", error = ex.Message });
            }
        }


    }
}
