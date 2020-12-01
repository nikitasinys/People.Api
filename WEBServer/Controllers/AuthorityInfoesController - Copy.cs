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
    public class AuthorityInfoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public AuthorityInfoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/AuthorityInfoes
        [HttpGet]
        public IEnumerable<AuthorityInfo> GetAuthorityInfo()
        {
            return _context.AuthorityInfo;
        }

        // GET: api/AuthorityInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorityInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorityInfo = await _context.AuthorityInfo.FindAsync(id);

            if (authorityInfo == null)
            {
                return NotFound();
            }

            return Ok(authorityInfo);
        }

        // PUT: api/AuthorityInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorityInfo([FromRoute] int id, [FromBody] AuthorityInfo authorityInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authorityInfo.IdDw)
            {
                return BadRequest();
            }

            _context.Entry(authorityInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorityInfoExists(id))
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

        // POST: api/AuthorityInfoes
        [HttpPost]
        public async Task<IActionResult> PostAuthorityInfo([FromBody] AuthorityInfo authorityInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AuthorityInfo.Add(authorityInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthorityInfoExists(authorityInfo.IdDw))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthorityInfo", new { id = authorityInfo.IdDw }, authorityInfo);
        }

        // DELETE: api/AuthorityInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorityInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorityInfo = await _context.AuthorityInfo.FindAsync(id);
            if (authorityInfo == null)
            {
                return NotFound();
            }

            _context.AuthorityInfo.Remove(authorityInfo);
            await _context.SaveChangesAsync();

            return Ok(authorityInfo);
        }

        private bool AuthorityInfoExists(int id)
        {
            return _context.AuthorityInfo.Any(e => e.IdDw == id);
        }
    }
}