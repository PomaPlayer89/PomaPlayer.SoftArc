using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Logic.Interfaces.Services;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Services
{
    public class CustomerService : ICustomerService
    {
        public IQueryable<Customer> GetCustomersQueryable(DataContext dataContext, CustomerFilter filter)
        {
            var customerQuery = dataContext.Customers
                .AsNoTracking();

            if (filter.IsnCenter.HasValue)
                customerQuery = customerQuery.Where(x => x.IsnCenter == filter.IsnCenter.Value);

            return customerQuery;
        }

        public Customer GetInfoCustomer(DataContext dataContext, Guid isnCustomer)
        {
            var customer = dataContext.Customers
                .AsNoTracking()
                .Include(x => x.Center)
                .Include(x => x.CustomerTrainers)
                    .ThenInclude(x => x.Trainer)
                .FirstOrDefault(x => x.IsnNode == isnCustomer)
                    ?? throw new Exception($"Клиента с идентификатором {isnCustomer} не существует");

            return customer;
        }
    }
}
