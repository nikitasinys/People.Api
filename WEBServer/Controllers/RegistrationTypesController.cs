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
    public class RegistrationTypesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public RegistrationTypesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/RegistrationTypes
        [HttpGet]
        public IEnumerable<RegistrationType> GetRegistrationType()
        {
            return _context.RegistrationType;
        }

        // GET: api/RegistrationTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationType = await _context.RegistrationType.FindAsync(id);

            if (registrationType == null)
            {
                return NotFound();
            }

            return Ok(registrationType);
        }

        // PUT: api/RegistrationTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrationType([FromRoute] int id, [FromBody] RegistrationType registrationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registrationType.IdTypeRegistration)
            {
                return BadRequest();
            }

            _context.Entry(registrationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationTypeExists(id))
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

        // POST: api/RegistrationTypes
        [HttpPost]
        public async Task<IActionResult> PostRegistrationType([FromBody] RegistrationType registrationType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RegistrationType.Add(registrationType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistrationTypeExists(registrationType.IdTypeRegistration))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegistrationType", new { id = registrationType.IdTypeRegistration }, registrationType);
        }

        // DELETE: api/RegistrationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registrationType = await _context.RegistrationType.FindAsync(id);
            if (registrationType == null)
            {
                return NotFound();
            }

            _context.RegistrationType.Remove(registrationType);
            await _context.SaveChangesAsync();

            return Ok(registrationType);
        }

        private bool RegistrationTypeExists(int id)
        {
            return _context.RegistrationType.Any(e => e.IdTypeRegistration == id);
        }
    }
}