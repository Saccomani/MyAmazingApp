using App.Core;
using App.Core.Models;
using App.Core.Providers;
using App.Domain.Interfaces;

using MyAmazingMauiApp.Sections;
using System.Diagnostics;

namespace MyAmazingMauiApp
{
	/// <summary>
	/// Tela de listagem dos produtos
	/// </summary>
	public partial class MainPage : ContentPage
	{
		readonly ProductsListViewModel viewModel;
		public MainPage()
		{
			InitializeComponent();


			var repo = ServicesProvider.GetService<IProductRepository>();
			
			BindingContext = viewModel = new ProductsListViewModel(repo);
			
			viewModel.SelectedItemsText = $"Produtos Selecionados (0)";

		}
		private void ToolbarItem_Clicked(object sender, EventArgs e)
		=> Shell.Current.Navigation.PushAsync(new AddProductsPage());

		private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selected = e.CurrentSelection[0] as ProductModel;

			if (selected == null)
				return;

			selected.Selected = !selected.Selected;
		}
		protected override async void OnAppearing()
		{
			Dispatcher.DispatchDelayed(TimeSpan.FromMicroseconds(400), async () =>
			{
				await viewModel.loadProductsFromDbCommand.ExecuteAsync(null);
				RefreshCountSelected();
			});
		}
		void RefreshCountSelected()
		{
			var selecteds = viewModel.Products.ToList().Where(x => x.Selected).Count();
			viewModel.SelectedItemsText = $"Produtos Selecionados ({selecteds})";
		}

		private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			viewModel.Products.ToList().ForEach(x => x.Selected = e.Value);
			RefreshCountSelected();
		}

		private void RefreshCount(object sender, CheckedChangedEventArgs e)
			=> RefreshCountSelected();


		private void OpenSelectedProducts_Clicked(object sender, EventArgs e)
		=> Shell.Current.Navigation.PushAsync(new ViewSelectedProductsPage(viewModel.Products.Where(x => x.Selected).ToList()));
	}
}
