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
    public class MyRaceController : Controller
    {
        private readonly RaceAppDb _context;

        public MyRaceController(RaceAppDb context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<MyRace> GetMyRace()
        {
            return _context.MyRace;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMyRace([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myRace = await _context.MyRace.SingleOrDefaultAsync(m => m.Id == id);

            if (myRace == null)
            {
                return NotFound();
            }

            return Ok(myRace);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostMyRace([FromBody] MyRace myRace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MyRace.Add(myRace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyRace", new { id = myRace.Id }, myRace);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyRace([FromRoute] long id, [FromForm] MyRace myRace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myRace.Id)
            {
                return BadRequest();
            }

            _context.Entry(myRace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyRaceExists(id))
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
        public async Task<IActionResult> DeleteMyRace([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myRace = await _context.MyRace.SingleOrDefaultAsync(m => m.Id == id);
            if (myRace == null)
            {
                return NotFound();
            }

            _context.MyRace.Remove(myRace);
            await _context.SaveChangesAsync();

            return Ok(myRace);
        }

        private bool MyRaceExists(long id)
        {
            return _context.MyRace.Any(e => e.Id == id);
        }
    }
}
