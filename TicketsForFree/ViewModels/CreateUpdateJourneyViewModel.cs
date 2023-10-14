namespace TicketsForFree.ViewModels
{
    public class CreateUpdateJourneyViewModel
    {
        public string? Transport { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }

    }
}
