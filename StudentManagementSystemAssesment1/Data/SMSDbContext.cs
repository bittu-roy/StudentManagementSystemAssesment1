using Microsoft.EntityFrameworkCore;
using StudentManagementSystemAssesment1.Models.Domain;

namespace StudentManagementSystemAssesment1.Data
{
    public class SMSDbContext: DbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
