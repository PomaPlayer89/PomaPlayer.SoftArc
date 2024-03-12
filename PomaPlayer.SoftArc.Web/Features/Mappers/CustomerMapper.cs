using AutoMapper;
using PomaPlayer.SoftArc.Storage.Models;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Customer;

namespace PomaPlayer.SoftArc.Web.Features.Mappers
{
    public sealed class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<EditCustomerDto, Customer>();
            CreateMap<Customer, EditCustomerDto>();
        }
    }
}
