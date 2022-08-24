using APICollection.Repository.Interfaces;
using APICollection.Data;
using APICollection.Models;

namespace APICollection.Repository
{
    public class PCRepository : IPCRepository
    {
        private readonly PolicyCollectionDbContext _context;
        public PCRepository(PolicyCollectionDbContext context)
        {
            _context = context;
        }
        public async Task<PolicyCollection> GetPolicyCollectionAsync(int id)
        {
            return await _context.PoliciesCollection.FindAsync(id); 
        }

    }
}

