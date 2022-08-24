using BCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BCWebAPI.Data
{
    public class PolicyCollectionFileDbContext:DbContext
    {
        //CLIPERT SERVER
        public DbSet <PolicyCollectionFile> PoliciesCollectionFile{ get; set; }
        public PolicyCollectionFileDbContext(DbContextOptions<PolicyCollectionFileDbContext> options):base(options)
        {

        }
    }
}
