using Microsoft.EntityFrameworkCore;

namespace Skillton.Core.Models
{
    public class SkilltonContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        private readonly string _connectionString;

        public SkilltonContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
