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
    public class AuthoritiesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public AuthoritiesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/Authorities
        [HttpGet]
        public IEnumerable<Authority> GetAuthority()
        {
            return _context.Authority;
        }

        // GET: api/Authorities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthority([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authority = await _context.Authority.FindAsync(id);

            if (authority == null)
            {
                return NotFound();
            }

            return Ok(authority);
        }

        // PUT: api/Authorities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthority([FromRoute] int id, [FromBody] Authority authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authority.IdAuthority)
            {
                return BadRequest();
            }

            _context.Entry(authority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorityExists(id))
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

        // POST: api/Authorities
        [HttpPost]
        public async Task<IActionResult> PostAuthority([FromBody] Authority authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Authority.Add(authority);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthorityExists(authority.IdAuthority))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthority", new { id = authority.IdAuthority }, authority);
        }

        // DELETE: api/Authorities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthority([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authority = await _context.Authority.FindAsync(id);
            if (authority == null)
            {
                return NotFound();
            }

            _context.Authority.Remove(authority);
            await _context.SaveChangesAsync();

            return Ok(authority);
        }

        private bool AuthorityExists(int id)
        {
            return _context.Authority.Any(e => e.IdAuthority == id);
        }
    }
}