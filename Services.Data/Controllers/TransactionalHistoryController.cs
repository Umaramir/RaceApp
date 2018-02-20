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
    public class TransactionalHistoryController : Controller
    {
        private readonly RaceAppDb _context;

        public TransactionalHistoryController(RaceAppDb context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<TransactionHistory> GetTransactionHistory()
        {
            return _context.TransactionHistory;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionHistory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionHistory = await _context.TransactionHistory.SingleOrDefaultAsync(m => m.Id == id);

            if (transactionHistory == null)
            {
                return NotFound();
            }

            return Ok(transactionHistory);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostUserProfile([FromBody] TransactionHistory transactionHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TransactionHistory.Add(transactionHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionHistory", new { id = transactionHistory.Id }, transactionHistory);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionHistory([FromRoute] long id, [FromForm] TransactionHistory transactionHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionHistoryExists(id))
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
        public async Task<IActionResult> DeleteTransactionHistory([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionHistory = await _context.TransactionHistory.SingleOrDefaultAsync(m => m.Id == id);
            if (transactionHistory == null)
            {
                return NotFound();
            }

            _context.TransactionHistory.Remove(transactionHistory);
            await _context.SaveChangesAsync();

            return Ok(transactionHistory);
        }

        private bool TransactionHistoryExists(long id)
        {
            return _context.TransactionHistory.Any(e => e.Id == id);
        }
    }
}
