using App.Core.Interfaces;
using CommunityToolkit.Maui;
using MyAmazingMauiApp.Platforms;
using Microsoft.Extensions.Logging;
using App.Domain.Interfaces;
using App.Data.Repositories;

namespace MyAmazingMauiApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<MyAmazingMauiApp.App>()
				.UseMauiCommunityToolkit()
				.RegisterServices()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("SourceSansPro-Bold.ttf", "Bold");
					fonts.AddFont("SourceSansPro-Regular.ttf", "Regular");
					fonts.AddFont("SourceSansPro-Light.ttf", "Light");
					fonts.AddFont("SourceSansPro-Semibold.ttf", "Semibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}

		/// <summary>
		/// Registra as injeções de independencias
		/// </summary>
		/// <param name="mauiAppBuilder"></param>
		/// <returns></returns>
		public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddSingleton<IDatabasePath, DatabasePathImplementation>();

			mauiAppBuilder.Services.AddTransient<IProductRepository, ProductRespository>();

			return mauiAppBuilder;
		}
	}
}
