using Microsoft.Extensions.DependencyInjection;
using PomaPlayer.SoftArc.Storage.MS_SQL.InitDatabase;

namespace PomaPlayer.SoftArc.Storage.MS_SQL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStorageServices(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseInit>();
        }
    }
}
