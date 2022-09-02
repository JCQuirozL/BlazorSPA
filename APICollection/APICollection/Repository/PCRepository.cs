using APICollection.Repository.Interfaces;
using APICollection.Data;
using APICollection.Entities;
using APICollection.Models;
using Microsoft.EntityFrameworkCore;

namespace APICollection.Repository
{
    public class PCRepository : IPCRepository
    {
        private readonly PolicyCollectionDbContext context;
        public PCRepository(PolicyCollectionDbContext context)
        {
            this.context = context;
        }


        public async Task<List<PolicyCollection>> Get()
        {
            return await context.PoliciesCollection.Include(p => p.Comments).ToListAsync();
        }
        public async Task<List<ReiceivablePolicy>> GetPoliciesAsync()
        {
            //PIService => Leasing
            //PCFile => Clipert

            return await context.PoliciesCollection
                .Include(policy => policy.Comments)
                .Include(policy => policy.PolicyCollectionFile)
                .Include(policy => policy.PolicyInformationService)
                .Select(policy => new ReiceivablePolicy
                {
                    Policy = policy.PolicyCollectionFile.Policy,
                    TotalPremium = policy.PolicyCollectionFile.TotalPremium,
                    ValidationDate = policy.ValidationDate,
                    PaymentFolio = policy.PolicyInformationService.PaymentFolio,
                    Bank = policy.PolicyInformationService.Bank,
                    AccountNumber = policy.AccountNumber,
                    IssueDate = policy.PolicyInformationService.IssueDate,
                    DepositAmount = policy.DepositAmount,
                    Reference = policy.PolicyCollectionFile.Reference,
                    Certificate = policy.PolicyCollectionFile.Certificate,
                    Invoice = policy.PolicyCollectionFile.Invoice,
                    InfoDate = policy.PolicyCollectionFile.InfoDate,
                    EmmiterCenter = policy.PolicyCollectionFile.EmitterCenter,
                    Validated = policy.Validated,
                    Comments = policy.Comments.Select(c => new PolicyCommentVM
                    {
                        Comment = c.Comment,
                        User = c.UserName,
                        CommentDate = c.CommentDate
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<PolicyCollection> GetPolicyCollectionAsync(int id)
        {
            return await context.PoliciesCollection.FindAsync(id);
        }

    }
}

