namespace APICollection.Repository.Interfaces
{
    using APICollection.Requests;
    using APICollection.Responses;
    public interface IPCRepository
    {
        /// <summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="policy"></param>
        /// <param name="validation"></param>
        /// </summary>
        /// <returns></returns>
        /// 

        public Task<IEnumerable<BillingData>> GetPoliciesAsync(DateTime? startDate, DateTime? endDate, String? policy, Boolean? validation);

        public Task<List<BillingData>> GatheringBillingData();

        public Task<Boolean> PatchPoliciesAsync(PatchPoliciesRequest[] request);
    }
}

