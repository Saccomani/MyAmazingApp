using App.Domain.Entities;
using App.Domain.Interfaces;
using App.ErrorHandling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace App.Core.ViewModels
{
	/// <summary>
	/// ViewModel Responsável por criar um novo produto
	/// </summary>
	public partial class CreateProductViewModel : BaseViewModel
	{

		readonly IProductRepository productRepository;

        public CreateProductViewModel()
        {
			productRepository = Core.Providers.ServicesProvider.GetService<IProductRepository>();

		}
		[ObservableProperty]
		string description;

		[ObservableProperty]
		decimal price;

		[RelayCommand]
		public async Task CreateNewProduct() {

			try
			{
				var newProduct = new Product
				{
					Descripton = description,
					Price = price,
				};

				newProduct.Validate();

				if (!newProduct.IsValid)
				{
					OnValidationFail?.Invoke(this, newProduct.ToString());
					return;
				}

				var inserResult =await productRepository.Insert(newProduct);

				if (inserResult == 0)
				{
					OnValidationFail?.Invoke(this, "Erro ao tentar cadastrar o produto.");
					return;
				}

				OnCreatedSuccess?.Invoke(this, EventArgs.Empty);

			}
			catch (Exception ex)
			{
				Logger.CaptureException(ex);
			}
		
		}

		public event EventHandler<string> OnValidationFail;
		public event EventHandler OnCreatedSuccess;
	}
}
