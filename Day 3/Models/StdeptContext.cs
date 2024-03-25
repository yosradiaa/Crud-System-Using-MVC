using Microsoft.EntityFrameworkCore;
namespace Day_3.Models
{
    public class StdeptContext : DbContext
    {
        public StdeptContext()
        {
        }

        //StdeptContext() { }
        StdeptContext(DbContextOptions options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Yosra\\SQLEXPRESS;Database=StudentDept;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}