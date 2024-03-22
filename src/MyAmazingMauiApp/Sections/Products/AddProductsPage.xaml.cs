using App.Core.ViewModels;

namespace MyAmazingMauiApp.Sections
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProductsPage : ContentPage
	{

		readonly CreateProductViewModel viewModel;
		public AddProductsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new CreateProductViewModel();

			viewModel.OnValidationFail += ViewModel_OnValidationFail;
			viewModel.OnCreatedSuccess += ViewModel_OnCreatedSuccess;
		}

		private void ViewModel_OnCreatedSuccess(object? sender, EventArgs e)
			=> Shell.Current.Navigation.PopAsync();

		private void ViewModel_OnValidationFail(object? sender, string e)
		{
			lblErro.Text = e;
		}
	}
}