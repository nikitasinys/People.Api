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
    public class CountryInfoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public CountryInfoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/CountryInfoes
        [HttpGet]
        public IEnumerable<CountryInfo> GetCountryInfo()
        {
            return _context.CountryInfo;
        }

        // GET: api/CountryInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countryInfo = await _context.CountryInfo.FindAsync(id);

            if (countryInfo == null)
            {
                return NotFound();
            }

            return Ok(countryInfo);
        }

        // PUT: api/CountryInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryInfo([FromRoute] int id, [FromBody] CountryInfo countryInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countryInfo.IdDw)
            {
                return BadRequest();
            }

            _context.Entry(countryInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryInfoExists(id))
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

        // POST: api/CountryInfoes
        [HttpPost]
        public async Task<IActionResult> PostCountryInfo([FromBody] CountryInfo countryInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CountryInfo.Add(countryInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CountryInfoExists(countryInfo.IdDw))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCountryInfo", new { id = countryInfo.IdDw }, countryInfo);
        }

        // DELETE: api/CountryInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countryInfo = await _context.CountryInfo.FindAsync(id);
            if (countryInfo == null)
            {
                return NotFound();
            }

            _context.CountryInfo.Remove(countryInfo);
            await _context.SaveChangesAsync();

            return Ok(countryInfo);
        }

        private bool CountryInfoExists(int id)
        {
            return _context.CountryInfo.Any(e => e.IdDw == id);
        }
    }
}