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
    public class StreetsController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public StreetsController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/Streets
        [HttpGet]
        public IEnumerable<Street> GetStreet()
        {
            return _context.Street;
        }

        // GET: api/Streets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStreet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var street = await _context.Street.FindAsync(id);

            if (street == null)
            {
                return NotFound();
            }

            return Ok(street);
        }

        // PUT: api/Streets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStreet([FromRoute] int id, [FromBody] Street street)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != street.IdStreet)
            {
                return BadRequest();
            }

            _context.Entry(street).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StreetExists(id))
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

        // POST: api/Streets
        [HttpPost]
        public async Task<IActionResult> PostStreet([FromBody] Street street)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Street.Add(street);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StreetExists(street.IdStreet))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStreet", new { id = street.IdStreet }, street);
        }

        // DELETE: api/Streets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStreet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var street = await _context.Street.FindAsync(id);
            if (street == null)
            {
                return NotFound();
            }

            _context.Street.Remove(street);
            await _context.SaveChangesAsync();

            return Ok(street);
        }

        private bool StreetExists(int id)
        {
            return _context.Street.Any(e => e.IdStreet == id);
        }
    }
}