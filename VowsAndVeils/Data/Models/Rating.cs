namespace VowsAndVeils.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeddingDressId { get; set; }
        public int Score { get; set; }  
       
    }
}