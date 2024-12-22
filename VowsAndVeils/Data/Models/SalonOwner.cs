namespace VowsAndVeils.Data.Models
{
    public class SalonOwner
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserRole> Roles { get; set; }
        public List<WeddingDress> WeddingDresses { get; set; }
    }
}
