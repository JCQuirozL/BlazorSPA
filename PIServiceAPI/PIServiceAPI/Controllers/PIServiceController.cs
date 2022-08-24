using BCWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PIServiceAPI.Models;
using PIServiceAPI.Repository.Interfaces;

namespace APICollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PIServiceController : ControllerBase
    {
        private readonly PolicyInformationDbContext context;
        private readonly IPIRepository PolicyInfoRepositiry;
        public PIServiceController(IPIRepository PolicyInfoRepositiry, PolicyInformationDbContext context)
        {
            this.context = context;
            this.PolicyInfoRepositiry = PolicyInfoRepositiry;
        }

        // GET: api/PIService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyInformationService>>> GetPoliciesInformationService()
        {
            if (context.PoliciesInformationService == null)
            {
                return NotFound();
            }
            return await context.PoliciesInformationService.ToListAsync();
        }



        //POST: api/PIService/Policies
        [HttpPost("Policies")]
        public async Task<IActionResult> GetPolicies([FromBody] List<string> policies)
        {
            var PolicyInfo = await PolicyInfoRepositiry.GetPoliciesAsync();
            var Query = from policy in PolicyInfo where policies.Contains(policy.Policy) select policy;
            return Ok(Query);
        }

        // GET: api/PIService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyInformationService>> GetPoliciesInformationService(int id)
        {

            var PoliciesInformationService = await PolicyInfoRepositiry.GetPolicyInfoAsync(id);
            if (PolicyInfoRepositiry == null)
            {
                return NotFound("No information about the policy in Database");
            }

            return PoliciesInformationService;
        }

        // PUT: api/PIService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoliciesInformationService(int id, PolicyInformationService PoliciesInformationService)
        {
            if (id != PoliciesInformationService.PolicyInfoId)
            {
                return BadRequest();
            }

            context.Entry(PoliciesInformationService).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliciesInformationServiceExists(id))
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

        // POST: api/PIService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyInformationService>> PostPoliciesInformationService(PolicyInformationService PoliciesInformationService)
        {
            if (context.PoliciesInformationService == null)
            {
                return Problem("Entity set 'PolicyCollectionDbContext.PoliciesInformationService'  is null.");
            }
            context.PoliciesInformationService.Add(PoliciesInformationService);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetPoliciesInformationService", new { id = PoliciesInformationService.PolicyInfoId }, PoliciesInformationService);
        }

        // DELETE: api/PIService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoliciesInformationService(int id)
        {
            if (context.PoliciesInformationService == null)
            {
                return NotFound();
            }
            var PoliciesInformationService = await context.PoliciesInformationService.FindAsync(id);
            if (PoliciesInformationService == null)
            {
                return NotFound();
            }

            context.PoliciesInformationService.Remove(PoliciesInformationService);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliciesInformationServiceExists(int id)
        {
            return (context.PoliciesInformationService?.Any(e => e.PolicyInfoId == id)).GetValueOrDefault();
        }
    }
}
