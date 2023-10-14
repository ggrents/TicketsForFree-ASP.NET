namespace TicketsForFree.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int JourneyId { get; set; }
        public Journey? Journey { get; set; }

        public int SeatId { get; set; }

        public Seat? Seat { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
