namespace App.Core.Interfaces
{
	/// <summary>
	/// Usado para obter o endereço fisico do banco de dados
	/// </summary>
	public interface IDatabasePath
	{
		string DiretorioDb { get; }
	}
}
