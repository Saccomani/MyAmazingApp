using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using System;

namespace App.Core.Providers
{

	/// <summary>
	/// Service de injeção de independencia para obter as instancias das classes
	/// </summary>
	public static class ServicesProvider
	{
		public static TService GetService<TService>()
			=> Current.GetService<TService>();

		public static IServiceProvider Current
			=>
#if WINDOWS10_0_17763_0_OR_GREATER
			MauiWinUIApplication.Current.Services;
#elif ANDROID
                MauiApplication.Current.Services;
#elif IOS || MACCATALYST
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
	}
}
