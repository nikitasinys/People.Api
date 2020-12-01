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
    public class TownInfoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public TownInfoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/TownInfoes
        [HttpGet]
        public IEnumerable<TownInfo> GetTownInfo()
        {
            return _context.TownInfo;
        }

        // GET: api/TownInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTownInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var townInfo = await _context.TownInfo.FindAsync(id);

            if (townInfo == null)
            {
                return NotFound();
            }

            return Ok(townInfo);
        }

        // PUT: api/TownInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTownInfo([FromRoute] int id, [FromBody] TownInfo townInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != townInfo.IdDw)
            {
                return BadRequest();
            }

            _context.Entry(townInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TownInfoExists(id))
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

        // POST: api/TownInfoes
        [HttpPost]
        public async Task<IActionResult> PostTownInfo([FromBody] TownInfo townInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TownInfo.Add(townInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TownInfoExists(townInfo.IdDw))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTownInfo", new { id = townInfo.IdDw }, townInfo);
        }

        // DELETE: api/TownInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTownInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var townInfo = await _context.TownInfo.FindAsync(id);
            if (townInfo == null)
            {
                return NotFound();
            }

            _context.TownInfo.Remove(townInfo);
            await _context.SaveChangesAsync();

            return Ok(townInfo);
        }

        private bool TownInfoExists(int id)
        {
            return _context.TownInfo.Any(e => e.IdDw == id);
        }
    }
}