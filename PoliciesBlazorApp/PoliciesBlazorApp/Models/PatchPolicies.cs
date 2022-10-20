namespace PoliciesBlazorApp.Models
{
    //ViewModel (dto) para hacer el patch de policies
    public class PatchPolicies
    {
        public Policy Policy { get; set; }

        public PatchPolicies(Policy policy)
        {
            Policy = policy;
        }
    }
}
