using People.Repository.Abstration;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Repositories.Implementation
{
	class BaseRepository<TEntity, TDataContext> : IBaseRepository<TEntity> where TEntity : class, new() where TDataContext : DbContext
	{
		protected Data.Entities.PeopleDWContext DbContext { get; set; }
		//protected TDataContext DbContext { get; set; }
		public BaseRepository(TDataContext dbContext)
		{
			DbContext = dbContext;
		}

		public IEnumerable<TEntity> GetAuthority()
		{
			return DbContext.Set<TEntity>();
		}

		// GET: api/Authorities/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAuthority([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var authority = await DbContext.Authority.FindAsync(id);

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

			DbContext.Entry(authority).State = EntityState.Modified;

			try
			{
				await DbContext.SaveChangesAsync();
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

			DbContext.Authority.Add(authority);
			try
			{
				await DbContext.SaveChangesAsync();
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

			var authority = await DbContext.Authority.FindAsync(id);
			if (authority == null)
			{
				return NotFound();
			}

			DbContext.Authority.Remove(authority);
			await DbContext.SaveChangesAsync();

			return Ok(authority);
		}

		private bool AuthorityExists(int id)
		{
			return DbContext.Authority.Any(e => e.IdAuthority == id);
		}
	}
}
