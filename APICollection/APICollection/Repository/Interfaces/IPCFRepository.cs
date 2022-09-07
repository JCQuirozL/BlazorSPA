using APICollection.Entities;

namespace APICollection.Repository.Interfaces
{
    public interface IPCFRepository
    {
        public bool PolicyCFExists(string policy);
        public Task<List<PolicyCollectionFile>> GetAllPoliciesCollectionFilAsync();
        public Task PostPoliciesCollectionFileAsync(PolicyCollectionFile model);
        public Task SaveAsync();
    }
}
