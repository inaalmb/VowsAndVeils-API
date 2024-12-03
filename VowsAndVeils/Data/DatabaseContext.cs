using Microsoft.EntityFrameworkCore;
using VowsAndVeils.Data.Models;

namespace VowsAndVeils.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        
        } 
    }
}
