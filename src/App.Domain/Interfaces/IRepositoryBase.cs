using System.Linq.Expressions;

namespace App.Domain.Interfaces
{
	/// <summary>
	/// Declaração da repository base
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepositoryBase<T> where T : class
	{
		List<T> GetAll();
		Task<List<T>> Get();
		Task<T> Get(int id);
		Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
		Task<List<T>> Gets(Expression<Func<T, bool>> predicate = null);
		Task<T> Get(Expression<Func<T, bool>> predicate);
		Task<T> FindOne(Expression<Func<T, bool>> predicate = null);

		Task<int> Insert(T entity);
		Task<int> InsertOrReplaceAsync(T entity);
		Task<int> InsertAll(List<T> entities);
		Task<int> UpdateAsync(T entity);
		Task<int> Delete(T entity);


	}
}
