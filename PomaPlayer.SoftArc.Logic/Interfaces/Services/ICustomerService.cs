using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Interfaces.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetCustomersQueryable(DataContext dataContext, CustomerFilter filter);

        Customer GetInfoCustomer(DataContext dataContext, Guid isnCustomer);
    }
}
