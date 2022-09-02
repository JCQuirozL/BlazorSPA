using APICollection.Entities;
using APICollection.Models;

namespace APICollection.Repository.Interfaces
{
    public interface IPCRepository
    {
        public Task<PolicyCollection> GetPolicyCollectionAsync(int id);

        public Task <List<ReiceivablePolicy>> GetPoliciesAsync();

        public Task<List<PolicyCollection>> Get();
    }
}
