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
    public class StreetInfoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public StreetInfoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/StreetInfoes
        [HttpGet]
        public IEnumerable<StreetInfo> GetStreetInfo()
        {
            return _context.StreetInfo;
        }

        // GET: api/StreetInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStreetInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var streetInfo = await _context.StreetInfo.FindAsync(id);

            if (streetInfo == null)
            {
                return NotFound();
            }

            return Ok(streetInfo);
        }

        // PUT: api/StreetInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStreetInfo([FromRoute] int id, [FromBody] StreetInfo streetInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != streetInfo.IdDw)
            {
                return BadRequest();
            }

            _context.Entry(streetInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StreetInfoExists(id))
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

        // POST: api/StreetInfoes
        [HttpPost]
        public async Task<IActionResult> PostStreetInfo([FromBody] StreetInfo streetInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StreetInfo.Add(streetInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StreetInfoExists(streetInfo.IdDw))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStreetInfo", new { id = streetInfo.IdDw }, streetInfo);
        }

        // DELETE: api/StreetInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStreetInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var streetInfo = await _context.StreetInfo.FindAsync(id);
            if (streetInfo == null)
            {
                return NotFound();
            }

            _context.StreetInfo.Remove(streetInfo);
            await _context.SaveChangesAsync();

            return Ok(streetInfo);
        }

        private bool StreetInfoExists(int id)
        {
            return _context.StreetInfo.Any(e => e.IdDw == id);
        }
    }
}