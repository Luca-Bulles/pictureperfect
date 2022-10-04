using ContentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentAPI.Data
{
    //Used to communicate with the database
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Content> Contents { get; set; }
    }
}
