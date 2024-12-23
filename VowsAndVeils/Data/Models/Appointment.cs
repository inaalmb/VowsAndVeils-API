using System.Data;

namespace VowsAndVeils.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeddingDressId { get; set; }
        public WeddingDress WeddingDress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
