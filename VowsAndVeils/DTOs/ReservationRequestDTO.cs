namespace VowsAndVeils.DTOs
{
    public class ReservationRequestDTO
    {
        public int UserId { get; set; }
        public int AdvertisementId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
