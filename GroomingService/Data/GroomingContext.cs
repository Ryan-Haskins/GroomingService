using Microsoft.EntityFrameworkCore;
using GroomingService.Models;
namespace GroomingService.Data
{
    public class GroomingContext : DbContext
    {
        public GroomingContext(DbContextOptions<GroomingContext> opt) : base(opt)
        {
            
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}