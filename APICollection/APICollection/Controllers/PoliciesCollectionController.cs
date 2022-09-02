

namespace APICollection.Controllers
{
    using APICollection.Data;
    using APICollection.Entities;
    using APICollection.Models;
    using APICollection.Repository.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesCollectionController : ControllerBase
    {
        private readonly IPCRepository repository;

        public PoliciesCollectionController(IPCRepository repository)
        {
            this.repository = repository;

        }

        // GET: api/PoliciesCollection
        [HttpGet]
        public async Task<IEnumerable<ReiceivablePolicy>> GetPoliciesCollection()
        {
             return await repository.GetPoliciesAsync();
            
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<PolicyCollection>> Get()
        {
            return await repository.Get();

        }



        //// GET: api/PoliciesCollection/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PolicyCollection>> GetPolicyCollection(int id)
        //{
        //    var policyCollection = await PCRepository.GetPolicyCollectionAsync(id);

        //    if (policyCollection == null)
        //    {
        //        return NotFound("No registers found in Database");
        //    }
        //    return policyCollection;
        //}

        //// PUT: api/PoliciesCollection/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPolicyCollection(int id, PolicyCollection policyCollection)
        //{
        //    if (id != policyCollection.PolicyCollectionId)
        //    {
        //        return BadRequest();
        //    }

        //    context.Entry(policyCollection).State = EntityState.Modified;

        //    try
        //    {
        //        await context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PolicyCollectionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/PoliciesCollection
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PolicyCollection>> PostPolicyCollection(PolicyCollection policyCollection)
        //{
        //    if (context.PoliciesCollection == null)
        //    {
        //        return Problem("Entity set 'PolicyCollectionDbContext.PoliciesCollection'  is null.");
        //    }
        //    context.PoliciesCollection.Add(policyCollection);
        //    await context.SaveChangesAsync();

        //    return CreatedAtAction("GetPolicyCollection", new { id = policyCollection.PolicyCollectionId }, policyCollection);
        //}

        //// DELETE: api/PoliciesCollection/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePolicyCollection(int id)
        //{
        //    if (context.PoliciesCollection == null)
        //    {
        //        return NotFound();
        //    }
        //    var policyCollection = await context.PoliciesCollection.FindAsync(id);
        //    if (policyCollection == null)
        //    {
        //        return NotFound();
        //    }

        //    context.PoliciesCollection.Remove(policyCollection);
        //    await context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PolicyCollectionExists(int id)
        //{
        //    return (context.PoliciesCollection?.Any(e => e.PolicyCollectionId == id)).GetValueOrDefault();
        //}
    }
}
