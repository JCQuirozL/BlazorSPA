using BCWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using PIServiceAPI.Models;
using PIServiceAPI.Repository.Interfaces;

namespace APICollection.Repository
{
    public class PIRepository : IPIRepository
    {
        private readonly PolicyInformationDbContext context;

        public PIRepository(PolicyInformationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<PolicyInformationService>> GetPoliciesAsync()
        {
            return await context.PoliciesInformationService.ToListAsync();
        }

        public async Task<PolicyInformationService> GetPolicyInfoAsync(int id)
        {
            return await context.PoliciesInformationService.FindAsync(id);
        }


    }
}