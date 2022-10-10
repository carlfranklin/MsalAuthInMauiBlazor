using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Configuration;
using MsalAuthInMauiBlazor.Data;
using MsalAuthInMauiBlazor.MsalClient;
using System.Reflection;

namespace MsalAuthInMauiBlazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            var executingAssembly = Assembly.GetExecutingAssembly();

            using var stream = executingAssembly.GetManifestResourceStream("MsalAuthInMauiBlazor.appsettings.json");

            var configuration = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IPCAWrapper, PCAWrapper>();
            builder.Configuration.AddConfiguration(configuration);

            return builder.Build();
        }
    }
}