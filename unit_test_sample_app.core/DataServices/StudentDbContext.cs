using Microsoft.EntityFrameworkCore;
using unit_test_sample_app.core.Models;

namespace unit_test_sample_app.core.DataServices
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options)
           : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
