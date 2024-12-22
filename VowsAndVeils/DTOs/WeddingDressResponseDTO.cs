using System.ComponentModel.DataAnnotations.Schema;

namespace VowsAndVeils.DTOs
{
    public class WeddingDressResponseDTO
    {
        public int Id { get; set; }
        public string UrlPhoto { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public int SalonOwnerId { get; set; }
        public string Size { get; set; }
        public string DressLength { get; set; }

    }
}
