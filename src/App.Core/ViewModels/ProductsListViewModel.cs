using App.Core.Extenssions;
using App.Core.Models;
using App.Core.ViewModels;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.ErrorHandling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core
{
	/// <summary>
	/// ViewModel responsável por listagem e seleção dos produtos
	/// </summary>
	public partial class ProductsListViewModel : BaseViewModel
	{

		readonly IProductRepository productRepository;

		[ObservableProperty]
		ObservableCollection<ProductModel> products = new();

		[ObservableProperty]
		bool isRefreshing;

		[ObservableProperty]
		string selectedItemsText;

		public ProductsListViewModel(IProductRepository productRepository)
		{
			this.productRepository = productRepository;

			SeedDb();
		}

		/// <summary>
		/// Inicia o banco de dados com alguns itens pré cadastrados
		/// </summary>
		private async void SeedDb()
		{

			try
			{
				var IsFirstLaunchEver = VersionTracking.IsFirstLaunchEver;

				if (IsFirstLaunchEver)
				{
					var products = new List<Product>();

					products.Add(new Product { Descripton = "Aparador com zircônias folheada a ouro 18k", Price = Random.Shared.Next(0, 1000) });
					products.Add(new Product { Descripton = "Aliança folheada a ouro 18k", Price = Random.Shared.Next(0, 1000) });
					products.Add(new Product { Descripton = "Aliança de prata 925", Price = Random.Shared.Next(0, 1000) });
					products.Add(new Product { Descripton = "Meia aliança de prata 925 com zircônias", Price = Random.Shared.Next(0, 1000) });
					products.Add(new Product { Descripton = "Anel entrelaçado de prata 925 com zircônias", Price = Random.Shared.Next(0, 1000) });
		
					var rowsAffecteds = await productRepository.InsertAll(products);

					Debug.WriteLine($"Produtos Inseridos no Seed {rowsAffecteds}");

				}
			}
			catch (Exception ex)
			{
				Logger.CaptureException(ex);
			}
		}

		[RelayCommand]
		public async Task loadProductsFromDb() {

			try
			{
				var productsFromDb = await productRepository.Gets();

				Products = new ObservableCollection<ProductModel>(productsFromDb.ToModel().OrderBy(a => a.Descripton));

				OnProductsLoaded?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				Logger.CaptureException(ex);
			}	
		}

		#region [Events]
		public event EventHandler OnProductsLoaded;
		#endregion

	}
}
