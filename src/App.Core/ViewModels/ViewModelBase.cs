using System;
using CommunityToolkit.Mvvm.ComponentModel;
namespace App.Core.ViewModels
{

	/// <summary>
	/// ViewModel base para abstração de algumas funcionalidades em comum em todas viewmodels filhas
	/// </summary>
	public partial class BaseViewModel : ObservableObject
	{
		public BaseViewModel() { }

	}
}
