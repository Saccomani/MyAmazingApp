using App.Core.Models;
using App.Domain.Entities;
using System.Collections.Generic;

namespace App.Core.Extenssions
{
	/// <summary>
	/// Toda conversão de uma classe para outra, no caso produtos, fica aqui nas extenssions
	/// </summary>
	public static class Products
	{
		public static List<ProductModel>  ToModel(this List<Product> productsModel)
		{
			var ret = new List<ProductModel>();


			foreach (var item in productsModel)
			{

				var product = new ProductModel { Descripton = item.Descripton, Price = item.Price };
				product.SetId(item.Id);

				ret.Add(product);
			}

			return ret;
		}
	}
}
