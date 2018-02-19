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
    public class DoorPrizeController : Controller
    {
        private readonly RaceAppDb _context;

        public DoorPrizeController(RaceAppDb context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<DoorPrize> GetDoorPrize()
        {
            return _context.DoorPrize;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoorPrize([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doorPrize = await _context.DoorPrize.SingleOrDefaultAsync(m => m.Id == id);

            if (doorPrize == null)
            {
                return NotFound();
            }

            return Ok(doorPrize);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostDoorPrize([FromBody] DoorPrize doorPrize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DoorPrize.Add(doorPrize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoorPrize", new { id = doorPrize.Id }, doorPrize);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoorPrize([FromRoute] long id, [FromForm] DoorPrize doorPrize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doorPrize.Id)
            {
                return BadRequest();
            }

            _context.Entry(doorPrize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoorPrizeExists(id))
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
        public async Task<IActionResult> DeleteDoorPrize([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doorPrize = await _context.DoorPrize.SingleOrDefaultAsync(m => m.Id == id);
            if (doorPrize == null)
            {
                return NotFound();
            }

            _context.DoorPrize.Remove(doorPrize);
            await _context.SaveChangesAsync();

            return Ok(doorPrize);
        }

        private bool DoorPrizeExists(long id)
        {
            return _context.DoorPrize.Any(e => e.Id == id);
        }
    }
}
