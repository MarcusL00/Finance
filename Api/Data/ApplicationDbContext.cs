using Microsoft.EntityFrameworkCore;
using Api.Models.Entities;
namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts => Set<Account>();

    }
}
