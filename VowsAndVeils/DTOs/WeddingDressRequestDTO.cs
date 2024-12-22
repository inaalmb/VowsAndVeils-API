using System.ComponentModel.DataAnnotations.Schema;

namespace VowsAndVeils.DTOs
{
    public class WeddingDressRequestDTO
    {
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public int SalonOwnerId { get; set; }
        public string Size {  get; set; }
        public string DressLength { get; set; }
    }
}
