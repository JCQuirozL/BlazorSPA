using APICollection.Data;
using APICollection.Models;
using APICollection.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APICollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesInformationServiceController : ControllerBase
    {
        private readonly IPISRepository repository;
        //private readonly PolicyCollectionDbContext _context;

        public PoliciesInformationServiceController(IPISRepository repository)
        {
            this.repository = repository;

        }

        // GET: api/PoliciesInformationService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyInformationService>>> GetPolicyInformationService()
        {
            if (repository.GetAllPoliciesInformationServiceAsync() == null)
            {
                return NotFound();
            }
            return await repository.GetAllPoliciesInformationServiceAsync();
        }

        //// GET: api/PoliciesInformationService/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PolicyInformationService>> GetPolicyInformationService(int id)
        //{
        //    if (_context.PolicyInformationService == null)
        //    {
        //        return NotFound();
        //    }
        //    var policyInformationService = await _context.PolicyInformationService.FindAsync(id);

        //    if (policyInformationService == null)
        //    {
        //        return NotFound();
        //    }

        //    return policyInformationService;
        //}

        //// PUT: api/PoliciesInformationService/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPolicyInformationService(int id, PolicyInformationService policyInformationService)
        //{
        //    if (id != policyInformationService.PolicyInfoId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(policyInformationService).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PolicyInformationServiceExists(id))
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

        [HttpPost("Policies")]
        public async Task<ActionResult> PostPIService([FromBody] PolicyInformationService[] PIService)
        {
            if (PIService == null)
            {
                return Problem("Entity is null");
            }

            //recorrer el arreglo
            for (var i = 0; i < PIService.Length; i++)
            {
                //preguntar si existe la póliza de la posición del arreglo actual
                if (!PIServiceExists(PIService[i].Policy))
                {
                    //sino existe, agregar la póliza
                    await repository.PostPoliciesInformationServiceAsync(PIService[i]);
                }
            }

            //guardar cambios
            await repository.SaveAsync();

            return Ok("Entities created");

        }

        private bool PIServiceExists(string policy)
        {
            return repository.PIServiceExists(policy);
        }
        // POST: api/PoliciesInformationService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PolicyInformationService>> PostPolicyInformationService(PolicyInformationService[] policyInformationService)
        //{
        //    if (_context.PolicyInformationService == null)
        //    {
        //        return Problem("Entity set 'PolicyCollectionDbContext.PolicyInformationService'  is null.");
        //    }
        //    _context.PolicyInformationService.Add(policyInformationService);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPolicyInformationService", new { id = policyInformationService.PolicyInfoId }, policyInformationService);
        //}

        // DELETE: api/PoliciesInformationService/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePolicyInformationService(int id)
        //{
        //    if (_context.PolicyInformationService == null)
        //    {
        //        return NotFound();
        //    }
        //    var policyInformationService = await _context.PolicyInformationService.FindAsync(id);
        //    if (policyInformationService == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PolicyInformationService.Remove(policyInformationService);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpPost("NotExistingPolicies")]
        //private async Task<IActionResult> ExistingPolicies(List<string> policiesNumberList)
        //{
        //    var bd = await _context.PolicyInformationService.ToListAsync();
        //    var pList = from x in bd where !(policiesNumberList.Contains(x.Policy)) select x;

        //    return Ok(pList);
        //}


        //private bool PolicyInformationServiceExists(int id)
        //{
        //    return (_context.PolicyInformationService?.Any(e => e.PolicyInfoId == id)).GetValueOrDefault();
        //}
    }
}
