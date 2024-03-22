using App.Core.Interfaces;

namespace MyAmazingMauiApp.Platforms
{
	public class DatabasePathImplementation : IDatabasePath
	{
		public DatabasePathImplementation() { }

		private string _diretorioDb;

		public string DiretorioDb
		{
			get
			{
				if (string.IsNullOrEmpty(_diretorioDb))
				{
					_diretorioDb = FileSystem.AppDataDirectory;
				}

				return _diretorioDb;
			}
		}
	}
}
