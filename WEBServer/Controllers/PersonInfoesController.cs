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
    public class PersonInfoesController : ControllerBase
    {
        private readonly PeopleDWContext _context;

        public PersonInfoesController(PeopleDWContext context)
        {
            _context = context;
        }

        // GET: api/PersonInfoes
        [HttpGet]
        public IEnumerable<PersonInfo> GetPersonInfo()
        {
            return _context.PersonInfo;
        }

        // GET: api/PersonInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonInfo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personInfo = await _context.PersonInfo.FindAsync(id);

            if (personInfo == null)
            {
                return NotFound();
            }

            return Ok(personInfo);
        }

        // PUT: api/PersonInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonInfo([FromRoute] long id, [FromBody] PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personInfo.IdPeople)
            {
                return BadRequest();
            }

            _context.Entry(personInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonInfoExists(id))
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

        // POST: api/PersonInfoes
        [HttpPost]
        public async Task<IActionResult> PostPersonInfo([FromBody] PersonInfo personInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonInfo.Add(personInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonInfoExists(personInfo.IdPeople))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonInfo", new { id = personInfo.IdPeople }, personInfo);
        }

        // DELETE: api/PersonInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonInfo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personInfo = await _context.PersonInfo.FindAsync(id);
            if (personInfo == null)
            {
                return NotFound();
            }

            _context.PersonInfo.Remove(personInfo);
            await _context.SaveChangesAsync();

            return Ok(personInfo);
        }

        private bool PersonInfoExists(long id)
        {
            return _context.PersonInfo.Any(e => e.IdPeople == id);
        }
    }
}