using Microsoft.AspNetCore.Mvc;
using TicketsForFree.Models;
using TicketsForFree.Services;
using TicketsForFree.Services.Interfaces;

namespace TicketsForFree.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeatsController : Controller
    {


        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetAll()
        {

            var journeys = await _seatService.GetAll();
            return Ok(journeys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetById(int id)
        {


            var seat = await _seatService.GetById(id);

            if (seat == null)
                return NotFound();

            return Ok(seat);
        }

        [HttpGet("vip")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetVipSeats()
        {

            var seats = await _seatService.GetVipSeats();
            return Ok(seats);
        }


        [HttpGet("reserved")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetReservedSeats()
        {

            var seats = await _seatService.GetReservedSeats();
            return Ok(seats);
        }

        [HttpGet("unreserved")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetUnreservedSeats()
        {

            var seats = await _seatService.GetUnreservedSeats();
            return Ok(seats);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJourney(int id)
        {
            await _seatService.DeleteSeat(id);
            var seats = await _seatService.GetAll();
            return Ok(seats);
        }


        [HttpPost]
        public async Task<IActionResult> AddSeat([FromBody] Seat seat)
        {
            try
            {
                if (seat == null)
                {
                    return BadRequest("Invalid seat data");
                }

                var addedSeat = await _seatService.AddSeat(seat);

                
                return Ok(addedSeat);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
