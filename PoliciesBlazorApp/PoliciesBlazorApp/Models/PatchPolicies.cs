namespace PoliciesBlazorApp.Models
{
    public class PatchPolicies
    {
        public Policy Policy { get; set; }

        public PatchPolicies(Policy policy)
        {
            Policy = policy;
        }
    }
}
