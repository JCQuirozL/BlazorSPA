using APICollection.Repository.Interfaces;
using APICollection.Data;
using Microsoft.EntityFrameworkCore;
using APICollection.Entities;

namespace APICollection.Repository
{
    public class PISRepository : IPISRepository
    {
        private readonly PolicyCollectionDbContext context;
        public PISRepository(PolicyCollectionDbContext context)
        {
            this.context = context;
        }

        public async Task<List<PolicyInformationService>> GetAllPoliciesInformationServiceAsync()
        {
            return await context.PolicyInformationService.ToListAsync();
        }

        public bool PIServiceExists(string policy)
        {
            return (context.PolicyInformationService?.Any(p => p.Policy == policy)).GetValueOrDefault();
        }

        public async Task PostPoliciesInformationServiceAsync(PolicyInformationService model)
        {

            await context.AddAsync(model);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
