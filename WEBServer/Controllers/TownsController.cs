using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using People.Data.Entities;

namespace PeopleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownsController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public TownsController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/Towns
        [HttpGet]
        public IEnumerable<Town> GetTown()
        {
            return _context.Town;
        }

        // GET: api/Towns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTown([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var town = await _context.Town.FindAsync(id);

            if (town == null)
            {
                return NotFound();
            }

            return Ok(town);
        }

        // PUT: api/Towns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTown([FromRoute] int id, [FromBody] Town town)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != town.IdTown)
            {
                return BadRequest();
            }

            _context.Entry(town).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TownExists(id))
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

        // POST: api/Towns
        [HttpPost]
        public async Task<IActionResult> PostTown([FromBody] Town town)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Town.Add(town);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TownExists(town.IdTown))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTown", new { id = town.IdTown }, town);
        }

        // DELETE: api/Towns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTown([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var town = await _context.Town.FindAsync(id);
            if (town == null)
            {
                return NotFound();
            }

            _context.Town.Remove(town);
            await _context.SaveChangesAsync();

            return Ok(town);
        }

        private bool TownExists(int id)
        {
            return _context.Town.Any(e => e.IdTown == id);
        }
    }
}