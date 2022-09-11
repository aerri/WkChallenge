using Microsoft.EntityFrameworkCore;
using WkChallenge.Infrastructure.Data;

namespace WkChallenge.Api;

public static class ExtensionMethods
{
	public static void MigrateDatabase(this WebApplication webApp)
	{
		using var scope = webApp.Services.CreateScope();
		using var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		appContext.Database.Migrate();
	}
}
