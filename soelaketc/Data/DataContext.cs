using Microsoft.EntityFrameworkCore;
using soelaketc.Entities;

namespace soelaketc.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
