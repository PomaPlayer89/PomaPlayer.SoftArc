using PomaPlayer.SoftArc.Web.Features.Interfaces;
using PomaPlayer.SoftArc.Web.Features.Managers;
using PomaPlayer.SoftArc.Web.Features.Mappers;

namespace PomaPlayer.SoftArc.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFeaturesServices(this IServiceCollection services)
        {
            services.AddTransient<ICenterManager, CenterManager>();
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ITrainerManager, TrainerManager>();
        }

        public static void AddAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CenterMapper),
                typeof(CustomerMapper),
                typeof(TrainerMapper));
        }
    }
}
