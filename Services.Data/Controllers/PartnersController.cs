using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceApp.Entities;
using Services.Data.Helpers;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Data.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PartnersController : Controller
    {
        private readonly RaceAppDb _context;

        public PartnersController(RaceAppDb context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<UserProfile> GetUserProfile()
        {
            return _context.UserProfile;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartners([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partners = await _context.Partners.SingleOrDefaultAsync(m => m.Id == id);

            if (partners == null)
            {
                return NotFound();
            }

            return Ok(partners);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostPartners([FromBody] Partners partners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Partners.Add(partners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpartners", new { id = partners.Id }, partners);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartners([FromRoute] long id, [FromForm] Partners partners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partners.Id)
            {
                return BadRequest();
            }

            _context.Entry(partners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnersExists(id))
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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartners([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partners = await _context.Partners.SingleOrDefaultAsync(m => m.Id == id);
            if (partners == null)
            {
                return NotFound();
            }

            _context.Partners.Remove(partners);
            await _context.SaveChangesAsync();

            return Ok(partners);
        }

        private bool PartnersExists(long id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }
    }
}
