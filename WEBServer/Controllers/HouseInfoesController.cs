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
    public class HouseInfoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public HouseInfoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/HouseInfoes
        [HttpGet]
        public IEnumerable<HouseInfo> GetHouseInfo()
        {
            return _context.HouseInfo;
        }

        // GET: api/HouseInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHouseInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var houseInfo = await _context.HouseInfo.FindAsync(id);

            if (houseInfo == null)
            {
                return NotFound();
            }

            return Ok(houseInfo);
        }

        // PUT: api/HouseInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouseInfo([FromRoute] int id, [FromBody] HouseInfo houseInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != houseInfo.IdDw)
            {
                return BadRequest();
            }

            _context.Entry(houseInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseInfoExists(id))
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

        // POST: api/HouseInfoes
        [HttpPost]
        public async Task<IActionResult> PostHouseInfo([FromBody] HouseInfo houseInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HouseInfo.Add(houseInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HouseInfoExists(houseInfo.IdDw))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHouseInfo", new { id = houseInfo.IdDw }, houseInfo);
        }

        // DELETE: api/HouseInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouseInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var houseInfo = await _context.HouseInfo.FindAsync(id);
            if (houseInfo == null)
            {
                return NotFound();
            }

            _context.HouseInfo.Remove(houseInfo);
            await _context.SaveChangesAsync();

            return Ok(houseInfo);
        }

        private bool HouseInfoExists(int id)
        {
            return _context.HouseInfo.Any(e => e.IdDw == id);
        }
    }
}