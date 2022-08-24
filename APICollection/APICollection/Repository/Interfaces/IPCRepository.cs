using APICollection.Models;

namespace APICollection.Repository.Interfaces
{
    public interface IPCRepository
    {
        public Task<PolicyCollection> GetPolicyCollectionAsync(int id);


    }
}
