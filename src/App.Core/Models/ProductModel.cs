using App.Domain.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.Core.Models
{
	/// <summary>
	/// Model que representa o produto na tela do usuário, herda do produto do dominio e acrescenta uma propriedade nova chamada selected
	/// para selecionar o item na tela
	/// </summary>
	public class ProductModel : Product, INotifyPropertyChanged
	{
		private bool selected;

		public bool Selected
		{
			get => selected;
			set
			{
				selected = value;
				OnPropertyChanged();
			}
		}



		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
