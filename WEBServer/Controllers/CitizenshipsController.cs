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
    public class CitizenshipsController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public CitizenshipsController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/Citizenships
        [HttpGet]
        public IEnumerable<Citizenship> GetCitizenship()
        {
            return _context.Citizenship;
        }

        // GET: api/Citizenships/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitizenship([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var citizenship = await _context.Citizenship.FindAsync(id);

            if (citizenship == null)
            {
                return NotFound();
            }

            return Ok(citizenship);
        }

        // PUT: api/Citizenships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitizenship([FromRoute] long id, [FromBody] Citizenship citizenship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citizenship.IdRecordCitizenship)
            {
                return BadRequest();
            }

            _context.Entry(citizenship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitizenshipExists(id))
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

        // POST: api/Citizenships
        [HttpPost]
        public async Task<IActionResult> PostCitizenship([FromBody] Citizenship citizenship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Citizenship.Add(citizenship);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CitizenshipExists(citizenship.IdRecordCitizenship))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCitizenship", new { id = citizenship.IdRecordCitizenship }, citizenship);
        }

        // DELETE: api/Citizenships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitizenship([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var citizenship = await _context.Citizenship.FindAsync(id);
            if (citizenship == null)
            {
                return NotFound();
            }

            _context.Citizenship.Remove(citizenship);
            await _context.SaveChangesAsync();

            return Ok(citizenship);
        }

        private bool CitizenshipExists(long id)
        {
            return _context.Citizenship.Any(e => e.IdRecordCitizenship == id);
        }
    }
}