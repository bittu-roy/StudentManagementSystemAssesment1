using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystemAssesment1.Data
{
    public class SMSAuthDbContext : IdentityDbContext
    {
        public SMSAuthDbContext(DbContextOptions<SMSAuthDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var studentRoleId = "468c42e6-6f01-4856-ab60-93c36abc0802";
            var adminRoleId = "f3420eb4-8707-4ec6-9d0d-d74b57c8e270";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = studentRoleId,
                    ConcurrencyStamp = studentRoleId,
                    Name = "Student",
                    NormalizedName = "Student".ToUpper()
                }
            };
            new IdentityRole
            {
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
