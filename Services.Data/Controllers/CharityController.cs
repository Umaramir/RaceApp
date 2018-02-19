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
    public class CharityController : Controller
    {
        private readonly RaceAppDb _context;

        public CharityController(RaceAppDb context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Charity> GetCharity()
        {
            return _context.Charity;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharity([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charity = await _context.Charity.SingleOrDefaultAsync(m => m.Id == id);

            if (charity == null)
            {
                return NotFound();
            }

            return Ok(charity);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostCharity([FromBody] Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Charity.Add(charity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharity", new { id = charity.Id }, charity);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharity([FromRoute] long id, [FromForm] Charity charity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charity.Id)
            {
                return BadRequest();
            }

            _context.Entry(charity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharityExists(id))
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
        public async Task<IActionResult> DeleteCharity([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charity = await _context.Charity.SingleOrDefaultAsync(m => m.Id == id);
            if (charity == null)
            {
                return NotFound();
            }

            _context.Charity.Remove(charity);
            await _context.SaveChangesAsync();

            return Ok(charity);
        }

        private bool CharityExists(long id)
        {
            return _context.Charity.Any(e => e.Id == id);
        }
    }
}
