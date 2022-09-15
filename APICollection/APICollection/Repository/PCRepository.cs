

namespace APICollection.Repository
{
    using APICollection.Repository.Interfaces;
    using APICollection.Data;
    using APICollection.Entities;
    using Microsoft.EntityFrameworkCore;
    using APICollection.ViewModels;
    using APICollection.Responses;
    using APICollection.Requests;
    public class PCRepository : IPCRepository
    {
        private readonly PolicyCollectionDbContext context;
        public PCRepository(PolicyCollectionDbContext context)
        {
            this.context = context;
        }

        public void AddPolicyCollectionHistory(PolicyCollection policyCollection)
        {
            //mapping policyHistory model to DB
            PolicyCollectionHistory policyCollectionHistory = new()
            {
                PolicyCollectionId = policyCollection.PolicyCollectionId,
                Policy = policyCollection.Policy,
                TotalPremium = policyCollection.TotalPremium,
                PaymentFolio = policyCollection.PaymentFolio,
                Bank = policyCollection.Bank,
                AccountNumber = policyCollection.AccountNumber,
                DepositAmount = policyCollection.DepositAmount,
                DepositDate = policyCollection.DepositDate,
                ReferenceId = policyCollection.ReferenceId,
                Certificate = policyCollection.Certificate,
                Invoice = policyCollection.Invoice,
                IssueDate = policyCollection.IssueDate,
                EmmiterCenter = policyCollection.EmmiterCenter,
                Validated = policyCollection.Validated,
                ValidationDate = policyCollection.ValidationDate,
                CreatedDate = policyCollection.CreatedDate,
                UpdatedDate = policyCollection.UpdatedDate
            };
            //adding model to DB
            context.PoliciesCollectionHistory.Add(policyCollectionHistory);

        }

        public async Task<IEnumerable<BillingData>> GatheringBillingData()
            //mapping JSON and creating list
            => await context.PoliciesCollection
                 .Include(policy => policy.Comments)
                 .Select(policy => new BillingData
                 {
                     Policy = policy.Policy,
                     Clipert = new ClipertData
                     {
                         TotalPremium = policy.TotalPremium,
                         Certificate = policy.Certificate,
                         Invoice = policy.Invoice,
                         SendingDateASE = policy.IssueDate,
                         EmmiterCenter = policy.EmmiterCenter
                     },
                     Leasing = new LeasingData
                     {
                         ValidationDate = policy.ValidationDate,
                         PaymentFolio = policy.PaymentFolio,
                         ReferenceId = policy.ReferenceId,
                         Bank = policy.Bank,
                         AccountNumber = policy.AccountNumber,
                         DocumentDate = policy.DepositDate,
                         DepositAmount = policy.DepositAmount

                     },
                     Validated = policy.Validated,
                     Comments = policy.Comments.Select(policyComment => new PolicyCommentVM
                     {
                         CommentType = policyComment.CommentType,
                         Comment = policyComment.Comment,
                         User = policyComment.UserName,
                         CommentDate = policyComment.CommentDate
                     }).ToList()
                 }).OrderBy(policy=>policy.Clipert.SendingDateASE).ToListAsync();


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

            //Filtering method by different criteria
            //PIService => Leasing
            //PCFile => Clipert

            IEnumerable<BillingData> billingData = await GatheringBillingData();

            //All params
            if ((startDate != null) && (endDate != null) && (policy != null) && (validation != null))
            {
                return billingData.Where(billingData => billingData.Validated == validation & billingData.Policy == policy
                & billingData.Clipert.SendingDateASE >= startDate
                & billingData.Clipert.SendingDateASE <= endDate);
            }

            //With emission date and Policy number
            if ((startDate != null) && (endDate != null) && (policy != null))
            {
                return billingData.Where(billingData => billingData.Policy == policy
                 && billingData.Clipert.SendingDateASE >= startDate
                 && billingData.Clipert.SendingDateASE <= endDate);
            }

            //Policy and validation
            if ((validation != null) && (policy != null))
            {
                return billingData.Where(billingData => billingData.Validated == validation & billingData.Policy == policy);

            }

            //Date
            if ((startDate != null) && (endDate != null))
            {
                return billingData.Where(billingData => billingData.Clipert.SendingDateASE >= startDate
                && billingData.Clipert.SendingDateASE <= endDate);
            }

            //Policy number
            if (policy != null)
            {
                return billingData.Where(billingData => billingData.Policy == policy);
            }

            //validation status
            if (validation != null)
            {
                return billingData.Where(billingData => billingData.Validated == validation);

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
                var invoice = request[i].Policy.Invoice;
                policy = await context.PoliciesCollection
                    .FirstOrDefaultAsync(p => p.Policy == policyNumber && p.Invoice == invoice);

                if (policy != null)
                {
                    policy.PaymentFolio = request[i].Policy.PaymentFolio;
                    policy.ReferenceId = request[i].Policy.ReferenceId;
                    policy.Bank = request[i].Policy.Bank;
                    policy.AccountNumber = request[i].Policy.AccountNumber;
                    policy.DepositDate = request[i].Policy.DocumentDate;
                    policy.DepositAmount = request[i].Policy.DepositAmount;
                    policy.Validated = request[i].Policy.Validated;
                   
                    //Si la póliza se marcó como validada, que se le inserte la fecha en que se está haciendo la validación
                    //if (policy.Validated)
                    //{
                    //    policy.ValidationDate = DateTime.Now;
                    //}
                    
                    if (context.Entry(policy).State == EntityState.Modified)
                    {
                        policy.UpdatedDate = DateTime.Now;
                        context.Update(policy);
                        AddPolicyCollectionHistory(policy);

                    }
                }

            }

            return await context.SaveChangesAsync() > 0;
        }

    }
}

