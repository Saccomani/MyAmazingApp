using App.Core.Interfaces;
using App.Domain.Entities;
using App.Domain.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Data.Repositories
{
	/// <summary>
	/// Repositório base com operações comuns para todos as tabelas
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
	{
		protected SQLiteAsyncConnection dbSqlite;
		private bool _disposed;

		public const SQLite.SQLiteOpenFlags Flags =
												  SQLite.SQLiteOpenFlags.ReadWrite |
												  SQLite.SQLiteOpenFlags.Create |
												  SQLite.SQLiteOpenFlags.SharedCache;
		public RepositoryBase()
        {
			var dataBasePath = Core.Providers.ServicesProvider.GetService<IDatabasePath>();
			var pathSqlite = Path.Combine(dataBasePath.DiretorioDb, "myAmazingAppDb.db3");

			if (string.IsNullOrEmpty(pathSqlite))
				throw new Exception("Database path is null");

			dbSqlite = new SQLiteAsyncConnection(pathSqlite, Flags);

			CreateTables();
		}

		async void CreateTables()
		{
			var result = await dbSqlite.CreateTableAsync<Product>();

			if (result == CreateTableResult.Created)
			{
				
			}

			//todo: log success or error
		}
		public SQLiteAsyncConnection GetDb() => dbSqlite;
		public AsyncTableQuery<T> AsQueryable() =>
				   dbSqlite.Table<T>();

		public async Task<List<T>> Get() =>
			await dbSqlite.Table<T>().ToListAsync();

		public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
		{
			var query = dbSqlite.Table<T>();

			if (predicate != null)
				query = query.Where(predicate);

			if (orderBy != null)
				query = query.OrderBy<TValue>(orderBy);

			return await query.ToListAsync();
		}

		public async Task<List<T>> Gets(Expression<Func<T, bool>> predicate = null)
		{
			var query = dbSqlite.Table<T>();

			if (predicate != null)
				query = query.Where(predicate);

			return await query.ToListAsync();
		}

		public async Task<T> Get(int id) =>
			 await dbSqlite.FindAsync<T>(id);

		public async Task<T> FindOne(Expression<Func<T, bool>> predicate = null) =>
			await dbSqlite.Table<T>().FirstOrDefaultAsync(predicate);

		public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
			await dbSqlite.FindAsync<T>(predicate);

		public async Task<int> Insert(T entity) =>
			 await dbSqlite.InsertAsync(entity);

		public async Task<int> InsertOrReplaceAsync(T entity) =>
		 await dbSqlite.InsertOrReplaceAsync(entity);

		public async Task<int> UpdateAsync(T entity) =>
			 await dbSqlite.UpdateAsync(entity);

		public async Task<int> Delete(T entity) =>
			 await dbSqlite.DeleteAsync(entity);

		public async Task<int> InsertAll(List<T> entities)
			=> await dbSqlite.InsertAllAsync(entities);

		public List<T> GetAll()
		{
			var query = dbSqlite.Table<T>();
			return query.ToListAsync().Result;
		}

	}
}
