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
    public class RaceCartController : Controller
    {
        private readonly RaceAppDb _context;

        public RaceCartController(RaceAppDb context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<RaceCart> GetRaceCart()
        {
            return _context.RaceCart;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRaceCart([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var raceCart = await _context.RaceCart.SingleOrDefaultAsync(m => m.Id == id);

            if (raceCart == null)
            {
                return NotFound();
            }

            return Ok(raceCart);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostRaceCart([FromBody] RaceCart raceCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RaceCart.Add(raceCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaceCart", new { id = raceCart.Id }, raceCart);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceCart([FromRoute] long id, [FromForm] RaceCart raceCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raceCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(raceCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceCartExists(id))
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
        public async Task<IActionResult> DeleteRaceCart([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var raceCart = await _context.RaceCart.SingleOrDefaultAsync(m => m.Id == id);
            if (raceCart == null)
            {
                return NotFound();
            }

            _context.RaceCart.Remove(raceCart);
            await _context.SaveChangesAsync();

            return Ok(raceCart);
        }

        private bool RaceCartExists(long id)
        {
            return _context.RaceCart.Any(e => e.Id == id);
        }
    }
}
