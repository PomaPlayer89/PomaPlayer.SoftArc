using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Customer;

namespace PomaPlayer.SoftArc.Web.Features.Interfaces
{
    public interface ICustomerManager
    {
        Task CreateCustomerAsync(EditCustomerDto source, CancellationToken cancellationToken);

        Task UpdateCustomerAsync(EditCustomerDto source, CancellationToken cancellationToken);

        Task<CustomerDto> DeleteCustomerAsync(Guid isnCustomer, CancellationToken cancellationToken);

        Task<EditCustomerDto> GetCustomerAsync(Guid isnCustomer);

        Task<CustomerDto[]> GetListCustomersAsync(CustomerFilter filter);

        Task<InfoCustomerDto> GetInfoCustomerAsync(Guid isnCustomer);
    }
}
