using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Data.Repositories
{
	/// <summary>
	/// Repositório de produtos
	/// </summary>
	public class ProductRespository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRespository()
		{ 
		
		}
	}
}
