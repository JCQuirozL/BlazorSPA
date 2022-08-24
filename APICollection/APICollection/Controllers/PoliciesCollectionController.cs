using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICollection.Data;
using APICollection.Models;
using APICollection.Repository.Interfaces;

namespace APICollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesCollectionController : ControllerBase
    {
        private readonly IPCRepository PCRepository;
        private readonly PolicyCollectionDbContext context;

        public PoliciesCollectionController(IPCRepository PCRepository, PolicyCollectionDbContext context)
        {
            this.context = context;
            this.PCRepository = PCRepository;
        }

        // GET: api/PoliciesCollection
        [HttpGet]
        public async Task <ActionResult<PolicyCollection>> GetPoliciesCollection()
        {
            if (context.PoliciesCollection == null)
            {
                return NotFound();
            }

            //PIService => Leasing
            //PCFile => Clipert

            var policiesList = await (from policyCollection in context.PoliciesCollection
                                join PCFile in context.PolicyCollectionFile on policyCollection.PolicyFileId equals PCFile.PolicyFileId
                                join PIService in context.PolicyInformationService on policyCollection.PolicyInfoId equals PIService.PolicyInfoId join PComments in context.PolicyComments on policyCollection.PolicyCollectionId equals PComments.PolicyColId
                                select new
                                {
                                    policy = PCFile.Policy,
                                    totalPremium = PCFile.TotalPremium,
                                    validationDate = policyCollection.ValidationDate,
                                    paymentFolio = PIService.PaymentFolio,
                                    bank = PIService.Bank,
                                    accountNumber = policyCollection.AccountNumber,
                                    issueDate = PIService.IssueDate,
                                    depositAmount = policyCollection.DepositAmount,
                                    reference = PCFile.Reference,
                                    certificate = PCFile.Certificate,
                                    invoice = PCFile.Invoice,
                                    infoDate = PCFile.InfoDate,
                                    emmiterCenter = PCFile.EmitterCenter,
                                    comments = PComments.Comment,
                                    validated=policyCollection.Validated
                                }).ToListAsync();
            //return await context.PoliciesCollection.ToListAsync();

            return Ok(policiesList);
        }

        // GET: api/PoliciesCollection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyCollection>> GetPolicyCollection(int id)
        {
            var policyCollection = await PCRepository.GetPolicyCollectionAsync(id);

            if (policyCollection == null)
            {
                return NotFound("No registers found in Database");
            }
            return policyCollection;
        }

        // PUT: api/PoliciesCollection/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyCollection(int id, PolicyCollection policyCollection)
        {
            if (id != policyCollection.PolicyCollectionId)
            {
                return BadRequest();
            }

            context.Entry(policyCollection).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyCollectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PoliciesCollection
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyCollection>> PostPolicyCollection(PolicyCollection policyCollection)
        {
            if (context.PoliciesCollection == null)
            {
                return Problem("Entity set 'PolicyCollectionDbContext.PoliciesCollection'  is null.");
            }
            context.PoliciesCollection.Add(policyCollection);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyCollection", new { id = policyCollection.PolicyCollectionId }, policyCollection);
        }

        // DELETE: api/PoliciesCollection/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyCollection(int id)
        {
            if (context.PoliciesCollection == null)
            {
                return NotFound();
            }
            var policyCollection = await context.PoliciesCollection.FindAsync(id);
            if (policyCollection == null)
            {
                return NotFound();
            }

            context.PoliciesCollection.Remove(policyCollection);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolicyCollectionExists(int id)
        {
            return (context.PoliciesCollection?.Any(e => e.PolicyCollectionId == id)).GetValueOrDefault();
        }
    }
}
