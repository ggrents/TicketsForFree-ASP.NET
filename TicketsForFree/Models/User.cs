﻿namespace TicketsForFree.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

}