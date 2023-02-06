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

        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<LoginPage>();

		builder.Services.AddTransient<OrderService>();
		builder.Services.AddTransient<OrderListDetailViewModel>();
		builder.Services.AddTransient<OrderListDetailPage>();

        builder.Services.AddSingleton<OrderListViewModel>();
        builder.Services.AddSingleton<OrderListPage>();

        builder.Services.AddSingleton<ManageViewModel>();
        builder.Services.AddSingleton<ManagePage>();

        builder.Services.AddSingleton<LocalizationViewModel>();
        builder.Services.AddSingleton<LocalizationPage>();

		return builder.Build();
	}
}
