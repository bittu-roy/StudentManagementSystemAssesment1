using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SMSAssessment1.UI.Model
{
    public class SMSAuthDbContext: IdentityDbContext
    {
        public SMSAuthDbContext(DbContextOptions<SMSAuthDbContext> options) : base(options)
        {

        }
    }
}
