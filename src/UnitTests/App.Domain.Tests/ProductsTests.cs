using App.Domain.Entities;

namespace App.Domain.Tests
{
	/// <summary>
	/// Valida todas as regras do dominio da entidade produto
	/// </summary>
	public class ProductsTests
	{
		[Fact]
		public void Validate_Product()
		{

			//arrange
			var product = new Product
			{
				Descripton = "Descrição do produto",
				Price = 50
			};

			//act
			product.Validate();

			//asset
			Assert.True(product.IsValid);
		}

		[Fact]
		public void Validate_Price_Fail()
		{

			//arrange
			var product = new Product
			{
				Descripton = "Descri��o do produto",
				Price = 0
			};

			//act
			product.Validate();
			var result = product.ValidationResult["Price"];

			//asset
			Assert.Equivalent(result, "O Preço do produto precisa estar entre R$ 10 até R$ 100");
		}


		[Fact]
		public void Validate_Description_Empty_Fails()
		{
			//arrange
			var product = new Product
			{
				Descripton = "",
				Price = 1
			};

			//act
			product.Validate();
			var resultToString = product.ToString();
			//asset
			var result = product.ValidationResult["Descripton"];

			Assert.Equivalent(result, "A Descrição do produto não pode ser vazia");
		}

		[Fact]
		public void Validate_ShortDescription_Fails()
		{
			//arrange
			var product = new Product
			{
				Descripton = "Abobo",
				Price = 20
			};

			//act
			product.Validate();

			//asset
			var result = product.ValidationResult["Descrição produto"];

			Assert.Equivalent(result, "A Descrição deve conter pelo menos 10 caracteres");
		}
	}
}