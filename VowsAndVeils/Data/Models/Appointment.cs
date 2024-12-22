using System.Data;

namespace VowsAndVeils.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AdvertisementId { get; set; }
        public DataSetDateTime StartDate { get; set; }
        public DataSetDateTime EndDate { get;set; }
    }
}
