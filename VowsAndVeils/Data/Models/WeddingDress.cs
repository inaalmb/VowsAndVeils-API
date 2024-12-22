using System.ComponentModel.DataAnnotations.Schema;

namespace VowsAndVeils.Data.Models
{
    public class WeddingDress
    {
        public int Id { get; set; }
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Size { get; set; }

        [ForeignKey(nameof(SalonOwnerId))]
        public int SalonOwnerId { get; set; }
        public string DressLength { get; set; }
    }

}
