﻿namespace TicketsForFree.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
