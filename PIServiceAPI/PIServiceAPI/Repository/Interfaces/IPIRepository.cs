using PIServiceAPI.Models;

namespace PIServiceAPI.Repository.Interfaces
{
    public interface IPIRepository
    {
        public Task<PolicyInformationService> GetPolicyInfoAsync(int id);

        public Task<List<PolicyInformationService>> GetPoliciesAsync();




    }
}
