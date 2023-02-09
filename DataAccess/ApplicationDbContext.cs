using Microsoft.EntityFrameworkCore;
using TestManyToMany.Models;

namespace TestManyToMany.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Tag> Tag { get; set; }
    }
}
