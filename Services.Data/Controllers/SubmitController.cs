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
    public class SubmitController : Controller
    {
        private readonly RaceAppDb _context;

        public SubmitController(RaceAppDb context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Submit> GetSubmit()
        {
            return _context.Submit;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubmit([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submit = await _context.Submit.SingleOrDefaultAsync(m => m.Id == id);

            if (submit == null)
            {
                return NotFound();
            }

            return Ok(submit);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostSubmit([FromBody] Submit submit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Submit.Add(submit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubmit", new { id = submit.Id }, submit);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubmit([FromRoute] long id, [FromForm] Submit submit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != submit.Id)
            {
                return BadRequest();
            }

            _context.Entry(submit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmitExists(id))
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
        public async Task<IActionResult> DeleteSubmit([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submit = await _context.Submit.SingleOrDefaultAsync(m => m.Id == id);
            if (submit == null)
            {
                return NotFound();
            }

            _context.Submit.Remove(submit);
            await _context.SaveChangesAsync();

            return Ok(submit);
        }

        private bool SubmitExists(long id)
        {
            return _context.Submit.Any(e => e.Id == id);
        }
    }
}
