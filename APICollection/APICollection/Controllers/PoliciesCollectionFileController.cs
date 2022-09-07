using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICollection.Data;
using APICollection.Repository.Interfaces;
using APICollection.Entities;

namespace APICollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesCollectionFileController : ControllerBase
    {
        //private readonly PolicyCollectionDbContext _context;
        private readonly IPCFRepository repository;

        public PoliciesCollectionFileController(IPCFRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/PoliciesCollectionFile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyCollectionFile>>> GetPolicyCollectionFile()
        {
            if (repository.GetAllPoliciesCollectionFilAsync() == null)
            {
                return NotFound();
            }
            return await repository.GetAllPoliciesCollectionFilAsync();
        }

        //// GET: api/PoliciesCollectionFile/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PolicyCollectionFile>> GetPolicyCollectionFile(int id)
        //{
        //    if (_context.PolicyCollectionFile == null)
        //    {
        //        return NotFound();
        //    }
        //    var policyCollectionFile = await _context.PolicyCollectionFile.FindAsync(id);

        //    if (policyCollectionFile == null)
        //    {
        //        return NotFound();
        //    }

        //    return policyCollectionFile;
        //}

        // PUT: api/PoliciesCollectionFile/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPolicyCollectionFile(int id, PolicyCollectionFile policyCollectionFile)
        //{
        //    if (id != policyCollectionFile.PolicyFileId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(policyCollectionFile).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PolicyCollectionFileExists(id))
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

        // POST: api/PoliciesCollectionFile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PolicyCollectionFile>> PostPolicyCollectionFile(PolicyCollectionFile policyCollectionFile)
        //{
        //    if (_context.PolicyCollectionFile == null)
        //    {
        //        return Problem("Entity set 'PolicyCollectionDbContext.PolicyCollectionFile'  is null.");
        //    }
        //    _context.PolicyCollectionFile.Add(policyCollectionFile);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPolicyCollectionFile", new { id = policyCollectionFile.PolicyFileId }, policyCollectionFile);
        //}

        [HttpPost("Policies")]
        public async Task<ActionResult<PolicyCollectionFile>> PostPoliciesCollectionFile([FromBody] PolicyCollectionFile[] policyCollectionFile)
        {
            if (policyCollectionFile == null)
            {
                return Problem("Policies info is null.");
            }

            for (var i = 0; i < policyCollectionFile.Length; i++)
            {
                if (!PolicyCFExists(policyCollectionFile[i].Policy))
                {
                    await repository.PostPoliciesCollectionFileAsync(policyCollectionFile[i]);
                }
            }

            await repository.SaveAsync();
            return Ok("Created policies");
        }

        private bool PolicyCFExists(string policy)
        {
            return repository.PolicyCFExists(policy);
        }

        //// DELETE: api/PoliciesCollectionFile/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePolicyCollectionFile(int id)
        //{
        //    if (_context.PolicyCollectionFile == null)
        //    {
        //        return NotFound();
        //    }
        //    var policyCollectionFile = await _context.PolicyCollectionFile.FindAsync(id);
        //    if (policyCollectionFile == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PolicyCollectionFile.Remove(policyCollectionFile);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PolicyCollectionFileExists(int id)
        //{
        //    return (_context.PolicyCollectionFile?.Any(e => e.PolicyFileId == id)).GetValueOrDefault();
        //}
    }
}
