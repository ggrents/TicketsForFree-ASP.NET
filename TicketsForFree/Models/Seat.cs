﻿namespace TicketsForFree.Models
{
    public class Seat
    {

        public int SeatId { get; set; }

        public int JourneyID { get; set; }
        public Journey? Journey { get; set; }
        public bool IsReserved { get; set; }
        public bool IsVIP { get; set; }


    }
}
