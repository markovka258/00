using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WorkCalendar.Data;
using WorkCalendar.WinUI;
using MatBlazor;
namespace WorkCalendar;

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

        // Регистрация контекста базы данных
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<AppState>(); 

        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthService>();

        builder.Services.AddMatBlazor();

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate(); // Применяет миграции, если они не были применены
        }
        return app;
    }
}
