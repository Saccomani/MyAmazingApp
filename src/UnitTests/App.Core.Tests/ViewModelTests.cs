using App.Domain.Entities;
using App.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Core.Tests
{
	public class ViewModelTests
	{
		
		/// <summary>
		/// Faz o teste de carregamento dos dados da viewmodel de listagem de produtos, ja testa o repository tambem
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task ProductsListViewModel_LoadProductsFromDb_LoadsAndOrdersProductsCorrectly()
		{
			// Arrange
			var mockProductRepository = new Mock<IProductRepository>();
			var products = new List<Product>
			{
				new Product { Descripton = "Product C", Price = 200 },
				new Product { Descripton = "Product A", Price = 100 },
				new Product { Descripton = "Product B", Price = 150 }
			};

		
			mockProductRepository.Setup(repo => repo.Gets(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(products);


			var viewModel = new ProductsListViewModel(mockProductRepository.Object);

			// Act
			await viewModel.loadProductsFromDb();

			// Assert
			var orderedDescriptions = viewModel.Products.Select(p => p.Descripton).ToList();
			Assert.Equal(3, viewModel.Products.Count);
			Assert.Equal("Product A", orderedDescriptions[0]);
			Assert.Equal("Product B", orderedDescriptions[1]);
			Assert.Equal("Product C", orderedDescriptions[2]);

	
			mockProductRepository.Verify(repo => repo.Gets(null), Times.Once);
		}
	}
}