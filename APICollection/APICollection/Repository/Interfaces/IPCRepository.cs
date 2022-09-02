namespace APICollection.Repository.Interfaces
{
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

        //With date, policy number and validation status
        public Task <List<BillingData>> GetPoliciesAsync(DateTime? startDate, DateTime? endDate, String? policy, Boolean? validation);


    }
}
