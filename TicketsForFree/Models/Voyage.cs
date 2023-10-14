using System.ComponentModel.DataAnnotations.Schema;
namespace TicketsForFree.Models
{
    public class Voyage
    {

        
        public int VoyageId { get; set; }

        public string? DriverName { get; set; }

        public int JourneyId { get; set; }
    }
}
