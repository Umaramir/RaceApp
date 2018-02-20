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
    public class MedalController : Controller
    {
        private readonly RaceAppDb _context;

        public MedalController(RaceAppDb context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Medal> GetMedal()
        {
            return _context.Medal;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medal = await _context.Medal.SingleOrDefaultAsync(m => m.Id == id);

            if (medal == null)
            {
                return NotFound();
            }

            return Ok(medal);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostMedal([FromBody] Medal medal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Medal.Add(medal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedal", new { id = medal.Id }, medal);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedal([FromRoute] long id, [FromForm] Medal medal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medal.Id)
            {
                return BadRequest();
            }

            _context.Entry(medal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedalExists(id))
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
        public async Task<IActionResult> DeleteMedal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medal = await _context.Medal.SingleOrDefaultAsync(m => m.Id == id);
            if (medal == null)
            {
                return NotFound();
            }

            _context.Medal.Remove(medal);
            await _context.SaveChangesAsync();

            return Ok(medal);
        }

        private bool MedalExists(long id)
        {
            return _context.Medal.Any(e => e.Id == id);
        }
    }
}
