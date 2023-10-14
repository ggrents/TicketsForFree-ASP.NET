using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using TicketsForFree.Models;
using TicketsForFree.Services;
using TicketsForFree.Services.Interfaces;
using TicketsForFree.ViewModels;

namespace TicketsForFree.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {

        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;
        private readonly IJourneyService _journeyService;
        private readonly ISeatService _seatService;

        public ReservationsController(IReservationService ReservationService, IUserService userService, IJourneyService journeyService, ISeatService seatService)
        {
            _reservationService = ReservationService;
            _userService = userService;
            _journeyService = journeyService;
            _seatService = seatService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {

            var res = await _reservationService.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetById(int id)
        {

            var res = await _reservationService.GetReservationById(id);

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllByUserId(int id)
        {

            var res = await _reservationService.GetReservationsForUser(id);

    
            return Ok(res);
        }


        [HttpGet("journey/{id}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllByJourneyId(int id)
        {

            var res = await _reservationService.GetReservationsForJourney(id);


            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            await _reservationService.RemoveReservation(id);
            var journeys = await _reservationService.GetAll();
            return Ok(journeys);
        }


        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] Reservation newRes)
        {
            if (newRes == null)
            {
                return BadRequest();
            }

            newRes.BookingTime = DateTime.Now;

            
            var user = await _userService.Get(newRes.UserId);
            var journey = await _journeyService.Get(newRes.JourneyId);
            var seat = await _seatService.GetById(newRes.SeatId);

            if (user == null || journey == null || seat == null)
            {
                
                return BadRequest("One or more entities not found");
            }


            newRes.User = user;
            newRes.Journey = journey;
            newRes.Seat = seat;

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var jsonString = JsonSerializer.Serialize(newRes, jsonOptions);



            await _reservationService.MakeReservation(newRes);

            newRes.User.Reservations.Add(newRes);
            newRes.Journey.Reservations.Add(newRes);



            return Ok(newRes);
        }



    }
}
