using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsForFree.Models
{

    [Table("Journey")]
    public class Journey
    {
        public int JourneyId { get; set; }
        public string? Transport { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }

        public int Capacity { get; set; }


        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
