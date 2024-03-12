using Microsoft.Extensions.DependencyInjection;
using PomaPlayer.SoftArc.Logic.Interfaces.Repositories;
using PomaPlayer.SoftArc.Logic.Interfaces.Services;
using PomaPlayer.SoftArc.Logic.Repositories;
using PomaPlayer.SoftArc.Logic.Services;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Extensions
{
    public static class ServiceCollectionExtenstions
    {
        public static void AddLogicServices(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Center>, CenterRepository>();
            services.AddSingleton<IRepository<Trainer>, TrainerRepository>();
            services.AddSingleton<IRepository<Customer>, CustomerRepository>();

            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICenterService, CenterService>();
            services.AddSingleton<ITrainerService, TrainerService>();
        }
    }
}
