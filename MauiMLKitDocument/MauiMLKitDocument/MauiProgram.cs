using Microsoft.Extensions.Logging;

namespace MauiMLKitDocument;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterServices()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}


    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
#if ANDROID
        mauiAppBuilder.Services.AddSingleton<IDocumentScannerService, MauiMLKitDocument.Platforms.Android.DocumentScannerService>();
#endif
        return mauiAppBuilder;
    }
}

