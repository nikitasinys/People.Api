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
    public class RegionInfoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public RegionInfoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/RegionInfoes
        [HttpGet]
        public IEnumerable<RegionInfo> GetRegionInfo()
        {
            return _context.RegionInfo;
        }

        // GET: api/RegionInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var regionInfo = await _context.RegionInfo.FindAsync(id);

            if (regionInfo == null)
            {
                return NotFound();
            }

            return Ok(regionInfo);
        }

        // PUT: api/RegionInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegionInfo([FromRoute] int id, [FromBody] RegionInfo regionInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != regionInfo.IdDw)
            {
                return BadRequest();
            }

            _context.Entry(regionInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionInfoExists(id))
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

        // POST: api/RegionInfoes
        [HttpPost]
        public async Task<IActionResult> PostRegionInfo([FromBody] RegionInfo regionInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RegionInfo.Add(regionInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegionInfoExists(regionInfo.IdDw))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegionInfo", new { id = regionInfo.IdDw }, regionInfo);
        }

        // DELETE: api/RegionInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegionInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var regionInfo = await _context.RegionInfo.FindAsync(id);
            if (regionInfo == null)
            {
                return NotFound();
            }

            _context.RegionInfo.Remove(regionInfo);
            await _context.SaveChangesAsync();

            return Ok(regionInfo);
        }

        private bool RegionInfoExists(int id)
        {
            return _context.RegionInfo.Any(e => e.IdDw == id);
        }
    }
}