using VowsAndVeils.Data.Models;

namespace VowsAndVeils.DTOs
{
    public class AdminResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Username { get; set; }
    }
}
