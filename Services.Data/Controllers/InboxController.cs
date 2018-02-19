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
    public class InboxController : Controller
    {
        private readonly RaceAppDb _context;

        public InboxController(RaceAppDb context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Inbox> GetInbox()
        {
            return _context.Inbox;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInbox([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inbox = await _context.Inbox.SingleOrDefaultAsync(m => m.Id == id);

            if (inbox == null)
            {
                return NotFound();
            }

            return Ok(inbox);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostInbox([FromBody] Inbox inbox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inbox.Add(inbox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInbox", new { id = inbox.Id }, inbox);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInbox([FromRoute] long id, [FromForm] Inbox inbox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inbox.Id)
            {
                return BadRequest();
            }

            _context.Entry(inbox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InboxExists(id))
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
        public async Task<IActionResult> DeleteInbox([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inbox = await _context.Inbox.SingleOrDefaultAsync(m => m.Id == id);
            if (inbox == null)
            {
                return NotFound();
            }

            _context.Inbox.Remove(inbox);
            await _context.SaveChangesAsync();

            return Ok(inbox);
        }

        private bool InboxExists(long id)
        {
            return _context.Inbox.Any(e => e.Id == id);
        }
    }
}
