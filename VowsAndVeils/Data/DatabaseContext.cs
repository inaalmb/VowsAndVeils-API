using Microsoft.EntityFrameworkCore;
using VowsAndVeils.Data.Models;

namespace VowsAndVeils.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<WeddingDress> WeddingDresses { get; set; }

        public DbSet<SalonOwner> SalonOwners { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        
        } 
    }
}
