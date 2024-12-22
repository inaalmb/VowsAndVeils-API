using System.Data;

namespace VowsAndVeils.DTOs
{
    public class AppointmentRequestDTO
    {
        public int UserId { get; set; }
        public string WeddingDressId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
