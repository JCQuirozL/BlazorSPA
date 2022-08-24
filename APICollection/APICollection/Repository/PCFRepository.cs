using APICollection.Repository.Interfaces;
using APICollection.Data;
using APICollection.Models;
using Microsoft.EntityFrameworkCore;

namespace APICollection.Repository
{
    public class PCFRepository : IPCFRepository
    {
        private readonly PolicyCollectionDbContext context;
        public PCFRepository(PolicyCollectionDbContext context)
        {
            this.context = context;
        }

        public async Task<List<PolicyCollectionFile>> GetAllPoliciesCollectionFilAsync()
        {
            return await context.PolicyCollectionFile.ToListAsync();
        }

        public bool PolicyCFExists(string policy)
        {
            return (context.PolicyCollectionFile?.Any(e => e.Policy == policy)).GetValueOrDefault();
        }

        public async Task PostPoliciesCollectionFileAsync(PolicyCollectionFile model)
        {
            await context.AddAsync(model);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
