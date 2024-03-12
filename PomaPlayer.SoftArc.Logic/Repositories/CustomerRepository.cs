using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Logic.Interfaces.Repositories;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public Customer Create(DataContext dataContext, Customer model)
        {
            var center = dataContext.Centers.FirstOrDefault(x => x.IsnNode == model.IsnCenter)
                ?? throw new Exception($"Центра с идентификатором {model.IsnCenter} не существует");

            model.IsnNode = Guid.NewGuid();
            dataContext.Customers.Add(model);

            return model;
        }

        public Customer Delete(DataContext dataContext, Guid isnNode)
        {
            var customer = dataContext.Customers.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Клиента с идентификатором {isnNode} не существует");

            dataContext.Customers.Remove(customer);

            return customer;
        }

        public Customer GetById(DataContext dataContext, Guid isnNode)
        {
            var customer = dataContext.Customers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsnNode == isnNode)
                    ?? throw new Exception($"Клиента с идентификатором {isnNode} не существует");

            return customer;
        }

        public Customer Update(DataContext dataContext, Customer model)
        {
            var customer = dataContext.Customers.FirstOrDefault(x => x.IsnNode == model.IsnNode)
                ?? throw new Exception($"Клиента с идентификатором {model.IsnNode} не существует");

            var center = dataContext.Centers.FirstOrDefault(x => x.IsnNode == model.IsnCenter)
                ?? throw new Exception($"Центра с идентификатором {model.IsnCenter} не существует");

            customer.IsnCenter = model.IsnCenter;
            customer.SurName= model.SurName;
            customer.Name = model.Name;
            customer.LastName = model.LastName;
            customer.Birthday= model.Birthday;
            customer.Center = center;

            return customer;
        }
    }
}
