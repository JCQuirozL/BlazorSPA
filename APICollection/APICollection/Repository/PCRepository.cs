using APICollection.Repository.Interfaces;
using APICollection.Data;
using APICollection.Entities;
using Microsoft.EntityFrameworkCore;
using APICollection.ViewModels;
using APICollection.Responses;

namespace APICollection.Repository
{
    public class PCRepository : IPCRepository
    {
        private readonly PolicyCollectionDbContext context;
        public PCRepository(PolicyCollectionDbContext context)
        {
            this.context = context;
        }

        public async Task<List<BillingData>> GatheringBillingData()
        
            => await context.PoliciesCollection
                 .Include(policy => policy.Comments)
                 .Include(policy => policy.PolicyCollectionFile)
                 .Include(policy => policy.PolicyInformationService)
                 .Select(policy => new BillingData
                 {
                     policy = policy.PolicyCollectionFile.Policy,
                     clipert = new ClipertData
                     {
                         TotalPremium = policy.PolicyCollectionFile.TotalPremium,
                         Reference = policy.PolicyCollectionFile.Reference,
                         Certificate = policy.PolicyCollectionFile.Certificate,
                         Invoice = policy.PolicyCollectionFile.Invoice,
                         InfoDate = policy.PolicyCollectionFile.InfoDate,
                         EmmiterCenter = policy.PolicyCollectionFile.EmitterCenter,
                     },
                     leasing = new LeasingData
                     {
                         ValidationDate = policy.ValidationDate,
                         PaymentFolio = policy.PolicyInformationService.PaymentFolio,
                         Bank = policy.PolicyInformationService.Bank,
                         AccountNumber = policy.AccountNumber,
                         IssueDate = policy.PolicyInformationService.IssueDate,
                         DepositAmount = policy.DepositAmount,
                     },
                     validated = policy.Validated,
                     comments = policy.Comments.Select(policyComment => new PolicyCommentVM
                     {
                         CommentType = policyComment.CommentType,
                         Comment = policyComment.Comment,
                         User = policyComment.UserName,
                         CommentDate = policyComment.CommentDate
                     }).ToList()
                 }).ToListAsync();


        /// <summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="policy"></param>
        /// <param name="validation"></param>
        /// </summary>
        /// <returns></returns>
        /// 


        public async Task<IEnumerable<BillingData>> GetPoliciesAsync(DateTime? startDate, DateTime? endDate, String? policy, Boolean? validation)
        {
            //PIService => Leasing
            //PCFile => Clipert

            List<BillingData> billingData = await GatheringBillingData();

            //All params
            if ((startDate != null) && (endDate != null) && (policy != null) && (validation != null))
            {
                return billingData.Where(billingData => billingData.validated == validation & billingData.policy == policy
                & billingData.leasing.IssueDate >= startDate
                & billingData.leasing.IssueDate <= endDate);
            }

            //With date and policy number
            if ((startDate != null) && (endDate != null) && (policy != null))
            {
                return billingData.Where(billingData => billingData.policy == policy
                 && billingData.leasing.IssueDate >= startDate
                 && billingData.leasing.IssueDate <= endDate);
            }

            //policy and validation
            if ((validation != null) && (policy != null))
            {
                return billingData.Where(billingData => billingData.validated == validation & billingData.policy == policy);

            }

            //Date
            if ((startDate != null) && (endDate != null))
            {
                return billingData.Where(billingData => billingData.leasing.IssueDate >= startDate
                && billingData.leasing.IssueDate <= endDate);
            }

            //policy number
            if (policy != null)
            {
                return billingData.Where(billingData => billingData.policy == policy);
            }

            //validation status
            if (validation != null)
            {
                return billingData.Where(billingData => billingData.validated == validation);

            }

            //no params

            return billingData;
        }

        public Task PatchPoliciesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

