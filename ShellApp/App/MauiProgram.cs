namespace ShalomCake;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<RateViewModel>();
        builder.Services.AddSingleton<RatePage>();

		builder.Services.AddTransient<OrderService>();
		builder.Services.AddTransient<ListDetailViewModel>();
		builder.Services.AddTransient<ListDetailPage>();

        builder.Services.AddSingleton<ListViewModel>();
        builder.Services.AddSingleton<ListPage>();

        builder.Services.AddSingleton<OrderViewModel>();
        builder.Services.AddSingleton<OrderPage>();

        builder.Services.AddSingleton<MapViewModel>();
        builder.Services.AddSingleton<MapPage>();

        builder.Services.AddSingleton<LocalizationViewModel>();
        builder.Services.AddSingleton<LocalizationPage>();

		return builder.Build();
	}
}
