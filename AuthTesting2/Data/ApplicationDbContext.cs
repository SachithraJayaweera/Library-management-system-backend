using AuthTesting2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
