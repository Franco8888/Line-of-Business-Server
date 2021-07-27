using Microsoft.Extensions.DependencyInjection;

// This service setup services when startup runs
namespace LOB_server_template.Services.SetupOperationServices
{
    public class SetupService
    {
        public static void SetupProgramServices(IServiceCollection services)
        {
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IDataBaseService, DatabaseService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<IAdminService, AdminService>();
        }
    }
}
