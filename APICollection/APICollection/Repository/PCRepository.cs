using APICollection.Repository.Interfaces;
using APICollection.Data;
using APICollection.Entities;
using Microsoft.EntityFrameworkCore;
using APICollection.ViewModels;
using APICollection.Responses;
using APICollection.Requests;

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
                 .Select(policy => new BillingData
                 {
                     policy = policy.Policy,
                     clipert = new ClipertData
                     {
                         TotalPremium = policy.TotalPremium,
                         Reference = policy.Reference,
                         Certificate = policy.Certificate,
                         Invoice = policy.Invoice,
                         SendingDateASE = policy.IssueDate,
                         EmmiterCenter = policy.EmmiterCenter
                     },
                     leasing = new LeasingData
                     {
                         ValidationDate = policy.ValidationDate,
                         PaymentFolio = policy.PaymentFolio,
                         Bank = policy.Bank,
                         AccountNumber = policy.AccountNumber,
                         DocumentDate = policy.DepositDate,
                         DepositAmount = policy.DepositAmount
                         
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
                & billingData.clipert.SendingDateASE >= startDate
                & billingData.clipert.SendingDateASE <= endDate);
            }

            //With date and policy number
            if ((startDate != null) && (endDate != null) && (policy != null))
            {
                return billingData.Where(billingData => billingData.policy == policy
                 && billingData.clipert.SendingDateASE >= startDate
                 && billingData.clipert.SendingDateASE <= endDate);
            }

            //policy and validation
            if ((validation != null) && (policy != null))
            {
                return billingData.Where(billingData => billingData.validated == validation & billingData.policy == policy);

            }

            //Date
            if ((startDate != null) && (endDate != null))
            {
                return billingData.Where(billingData => billingData.clipert.SendingDateASE >= startDate
                && billingData.clipert.SendingDateASE <= endDate);
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

      
        public async Task<Boolean> PatchPoliciesAsync(PatchPoliciesRequest[] request)
        {
            PolicyCollection policy = new();
            for (int i = 0; i < request.Length; i++)
            {
                var policyNumber = request[i].Policy.PolicyNumber;
                policy = await context.PoliciesCollection
                    .FirstOrDefaultAsync(p => p.Policy == policyNumber);

                if (policy != null)
                {
                    policy.PaymentFolio = request[i].Policy.PaymentFolio;
                    policy.Bank = request[i].Policy.Bank;
                    policy.AccountNumber = request[i].Policy.AccountNumber;
                    policy.DepositDate = request[i].Policy.DocumentDate;
                    policy.DepositAmount = request[i].Policy.DepositAmount;
                    policy.Validated = request[i].Policy.Validated;
                    policy.UpdatedDate = DateTime.Now;
                    //Si la póliza se marcó como validada, que se le inserte la fecha en que se está haciendo la validación
                    if (policy.Validated)
                    {
                        policy.ValidationDate = DateTime.Now;
                    }

                    context.Update(policy);
                }
                
            }

            return await context.SaveChangesAsync() > 0;
        }
    }
}

