using App.Core.Models;
using App.ErrorHandling;
using System.Collections.ObjectModel;

namespace MyAmazingMauiApp.Sections;

public partial class ViewSelectedProductsPage : ContentPage
{
	ObservableCollection<ProductModel> selectedProducts = new();
	
	public ViewSelectedProductsPage(List<ProductModel> selectedProducts)
	{
		InitializeComponent();


		foreach (var item in selectedProducts)
		{
			this.selectedProducts.Add(item);
		}

		lstProductsSelected.BindingContext = this;

	}

	protected override void OnAppearing()
	{
		this.BatchBegin();
		
		this.Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(400),() =>
		{
			lstProductsSelected.ItemsSource = this.selectedProducts;
		});

		RefreshResume();

		this.BatchCommit();
	}

	void RefreshResume()
		=> lblResumo.Text = $"Total: {this.selectedProducts.Sum(x => x.Price).ToString("C")}";

	private async void RemoveItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			var product = (sender as Button).CommandParameter as ProductModel;

			var result = await DisplayAlert("Pergunta", $"Deseja remover o item {product.Descripton}", "Sim", "Cancelar");

			if (!result) return;

			this.selectedProducts.Remove(product);

			RefreshResume();

		}
		catch (Exception ex)
		{
			Logger.CaptureException(ex);
		}
	}
}