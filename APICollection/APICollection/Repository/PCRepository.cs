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

        /// <summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="policy"></param>
        /// <param name="validation"></param>
        /// </summary>
        /// <returns></returns>
        /// 


        public async Task<List<BillingData>> GetPoliciesAsync(DateTime? startDate, DateTime? endDate, String? policy, Boolean? validation)
        {
            //PIService => Leasing
            //PCFile => Clipert

            //All params
            if ((startDate != null) && (endDate != null) && (policy != null) && (validation != null))
            {
                return await context.PoliciesCollection
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
                        Comment = policyComment.Comment,
                        User = policyComment.UserName,
                        CommentDate = policyComment.CommentDate
                    }).ToList()
                }).Where(billingData => billingData.validated == validation & billingData.policy == policy
                & billingData.leasing.IssueDate >= startDate
                & billingData.leasing.IssueDate <= endDate).ToListAsync();
            }

            //With date and policy number
            if ((startDate != null) && (endDate != null) && (policy != null))
            {
                return await context.PoliciesCollection
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
                        Comment = policyComment.Comment,
                        User = policyComment.UserName,
                        CommentDate = policyComment.CommentDate
                    }).ToList()
                }).Where(billingData => billingData.policy == policy
                && billingData.leasing.IssueDate >= startDate
                && billingData.leasing.IssueDate <= endDate).ToListAsync();
            }

            //policy and validation
            if ((validation != null) && (policy != null))
            {
                return await context.PoliciesCollection
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
                        Comment = policyComment.Comment,
                        User = policyComment.UserName,
                        CommentDate = policyComment.CommentDate
                    }).ToList()
                }).Where(billingData => billingData.validated == validation & billingData.policy == policy).ToListAsync();

            }

            //Date
            if ((startDate != null) && (endDate != null))
            {
                return await context.PoliciesCollection
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
                        Comment = policyComment.Comment,
                        User = policyComment.UserName,
                        CommentDate = policyComment.CommentDate
                    }).ToList()
                }).Where(billingData => billingData.leasing.IssueDate >= startDate
                && billingData.leasing.IssueDate <= endDate).ToListAsync();
            }

            //policy number
            if (policy != null)
            {
                return await context.PoliciesCollection
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
                        Comment = policyComment.Comment,
                        User = policyComment.UserName,
                        CommentDate = policyComment.CommentDate
                    }).ToList()
                }).Where(billingData => billingData.policy == policy).ToListAsync();
            }

            //validation status
            if (validation != null)
            {
                return await context.PoliciesCollection
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
                      Comment = policyComment.Comment,
                      User = policyComment.UserName,
                      CommentDate = policyComment.CommentDate
                  }).ToList()
              }).Where(billingData => billingData.validated == validation).ToListAsync();

            }

            //no params

            return await context.PoliciesCollection
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
                  Comment = policyComment.Comment,
                  User = policyComment.UserName,
                  CommentDate = policyComment.CommentDate
              }).ToList()
          }).ToListAsync();


        }

    }
}

