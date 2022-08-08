using DataAccess.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SQLServer
{
    public class TestAppKeptDbContext : DbContext, ITestAppKeptDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public TestAppKeptDbContext(DbContextOptions<TestAppKeptDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            base.OnModelCreating(builder);      
        }
    }
}