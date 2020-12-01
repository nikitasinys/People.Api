using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace People.Repository.Abstration
{
	public interface IBaseRepository<TEntity> where TEntity : class, new()
	{
		TEntity GetById(int id);
		TEntity GetByCondition(Expression<Func<TEntity, bool>> expression);
		IQueryable<TEntity> GetAll();
		IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> expression);

		TEntity Create(TEntity entity);
		void Update(TEntity entity);

		Task<TEntity> GetByIdAsync(int id);
		Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> expression);

		Task<List<TEntity>> GetAllAsync();
		Task<List<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> expression);

		Task<TEntity> CreateAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task SaveAsync();

		Task<List<TEntity>> CreateRangeAsync(List<TEntity> entities);
		Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);
		Task DeleteRangeAsync(List<TEntity> entities);
	}
}
