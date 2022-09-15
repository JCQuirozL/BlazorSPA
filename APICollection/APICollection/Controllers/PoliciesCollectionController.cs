

namespace APICollection.Controllers
{
    using APICollection.Repository.Interfaces;
    using APICollection.Requests;
    using APICollection.Responses;
    using APICollection.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PoliciesCollectionController : ControllerBase
    {
        private readonly IPCRepository repository;

        public PoliciesCollectionController(IPCRepository repository)
        {
            this.repository = repository;

        }

        /// <summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="policy"></param>
        /// <param name="validation"></param>
        /// </summary>
        /// <returns></returns>

        // GET: api/PoliciesCollection
        [HttpGet]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(404, StatusCode = 404, Type = typeof(ErrorResponse))]
        [ProducesResponseType(401, StatusCode = 401, Type = typeof(ErrorResponse))]
        [ProducesResponseType(400, StatusCode = 400, Type = typeof(ErrorResponse))]
        [ProducesResponseType(200, StatusCode = 200, Type = typeof(ServiceResult))]

        public async Task<IEnumerable<BillingData>> GetPoliciesCollection([FromQuery] DateTime? startDate, DateTime? endDate, String? policy, Boolean? validation)
        {
            return await repository.GetPoliciesAsync(startDate, endDate, policy, validation);

        }

        [HttpPatch]
        [ProducesResponseType(201, StatusCode = 201, Type = typeof(ServiceResult))]
        [ProducesResponseType(400, StatusCode = 400, Type = typeof(ErrorResponse))]
        [ProducesResponseType(401, StatusCode = 401, Type = typeof(ErrorResponse))]
        [ProducesResponseType(404, StatusCode = 404, Type = typeof(ErrorResponse))]
        [ProducesResponseType(500, StatusCode = 500, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> UpdatePolicies([FromBody] PatchPoliciesRequest[] request)
        {
            try
            {
                Boolean policesWereUpdated = await repository.PatchPoliciesAsync(request);

                if (request == null)
                    return BadRequest(new ErrorResponse { Success = false, Message = "Incorrect sent data" });

                if (policesWereUpdated)
                    return Created("UpdatePolicies", new ServiceResult { Data = request, Annotations = "Succesfully validated data." });
                else
                    return NotFound(new ErrorResponse { Success = false, Message = "Requested resource not found or changes have not been detected in current policy." });
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorResponse { Success = false, Message = "A problem has occurred during the operation." });

            }



        }


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


        //private bool PolicyCollectionExists(int id)
        //{
        //    return (context.PoliciesCollection?.Any(e => e.PolicyCollectionId == id)).GetValueOrDefault();
        //}
    }
}
