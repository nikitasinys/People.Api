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
    public class AuthorityTypesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public AuthorityTypesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/AuthorityTypes
        [HttpGet]
        public IEnumerable<AuthorityType> GetAuthorityType()
        {
            return _context.AuthorityType;
        }

        // GET: api/AuthorityTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorityType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorityType = await _context.AuthorityType.FindAsync(id);

            if (authorityType == null)
            {
                return NotFound();
            }

            return Ok(authorityType);
        }

        // PUT: api/AuthorityTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorityType([FromRoute] int id, [FromBody] AuthorityType authorityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authorityType.TypeAuthority)
            {
                return BadRequest();
            }

            _context.Entry(authorityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorityTypeExists(id))
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

        // POST: api/AuthorityTypes
        [HttpPost]
        public async Task<IActionResult> PostAuthorityType([FromBody] AuthorityType authorityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AuthorityType.Add(authorityType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthorityTypeExists(authorityType.TypeAuthority))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuthorityType", new { id = authorityType.TypeAuthority }, authorityType);
        }

        // DELETE: api/AuthorityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorityType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorityType = await _context.AuthorityType.FindAsync(id);
            if (authorityType == null)
            {
                return NotFound();
            }

            _context.AuthorityType.Remove(authorityType);
            await _context.SaveChangesAsync();

            return Ok(authorityType);
        }

        private bool AuthorityTypeExists(int id)
        {
            return _context.AuthorityType.Any(e => e.TypeAuthority == id);
        }
    }
}