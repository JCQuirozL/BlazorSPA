using Microsoft.EntityFrameworkCore;
using PIServiceAPI.Models;

namespace BCWebAPI.Data
{
    public class PolicyInformationDbContext:DbContext
    {
        //LEASING BD
        public DbSet< PolicyInformationService> PoliciesInformationService { get; set; }
        public PolicyInformationDbContext(DbContextOptions<PolicyInformationDbContext> options):base(options)
        {

        }

        public PolicyInformationDbContext()
        {
        }
    }
}
