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
    public class PersonPhotoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public PersonPhotoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/PersonPhotoes
        [HttpGet]
        public IEnumerable<PersonPhoto> GetPersonPhoto()
        {
            return _context.PersonPhoto;
        }

        // GET: api/PersonPhotoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonPhoto([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personPhoto = await _context.PersonPhoto.FindAsync(id);

            if (personPhoto == null)
            {
                return NotFound();
            }

            return Ok(personPhoto);
        }

        // PUT: api/PersonPhotoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonPhoto([FromRoute] long id, [FromBody] PersonPhoto personPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personPhoto.HashPhoto)
            {
                return BadRequest();
            }

            _context.Entry(personPhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonPhotoExists(id))
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

        // POST: api/PersonPhotoes
        [HttpPost]
        public async Task<IActionResult> PostPersonPhoto([FromBody] PersonPhoto personPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonPhoto.Add(personPhoto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonPhotoExists(personPhoto.HashPhoto))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonPhoto", new { id = personPhoto.HashPhoto }, personPhoto);
        }

        // DELETE: api/PersonPhotoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonPhoto([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personPhoto = await _context.PersonPhoto.FindAsync(id);
            if (personPhoto == null)
            {
                return NotFound();
            }

            _context.PersonPhoto.Remove(personPhoto);
            await _context.SaveChangesAsync();

            return Ok(personPhoto);
        }

        private bool PersonPhotoExists(long id)
        {
            return _context.PersonPhoto.Any(e => e.HashPhoto == id);
        }
    }
}