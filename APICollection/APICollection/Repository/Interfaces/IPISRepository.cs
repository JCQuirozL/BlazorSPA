using APICollection.Entities;

namespace APICollection.Repository.Interfaces
{
    public interface IPISRepository
    {
        public Task PostPoliciesInformationServiceAsync(PolicyInformationService model);
        public Task SaveAsync();

        public bool PIServiceExists(string policy);
        public Task<List<PolicyInformationService>> GetAllPoliciesInformationServiceAsync();

    }
}
