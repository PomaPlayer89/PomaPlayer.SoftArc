using AutoMapper;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Logic.Interfaces.Repositories;
using PomaPlayer.SoftArc.Logic.Interfaces.Services;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Center;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Customer;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer;
using PomaPlayer.SoftArc.Web.Features.Interfaces;

namespace PomaPlayer.SoftArc.Web.Features.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IRepository<Customer> _customerRepository;

        private readonly DataContext _dataContext;

        public CustomerManager(
            IMapper mapper,
            ICustomerService customerService,
            IRepository<Customer> customerRepository,
            DataContext dataContext)
        {
            _mapper = mapper;
            _customerService = customerService;
            _customerRepository = customerRepository;
            _dataContext = dataContext;
        }

        public async Task CreateCustomerAsync(EditCustomerDto source, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Customer>(source);

            _customerRepository.Create(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCustomerAsync(EditCustomerDto source, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Customer>(source);

            _customerRepository.Update(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<CustomerDto> DeleteCustomerAsync(Guid isnCustomer, CancellationToken cancellationToken)
        {
            var model = _customerRepository.Delete(_dataContext, isnCustomer);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerDto>(model);
        }

        public async Task<EditCustomerDto> GetCustomerAsync(Guid isnCustomer)
        {
            var model = _customerRepository.GetById(_dataContext, isnCustomer);

            return _mapper.Map<EditCustomerDto>(model);
        }

        public async Task<CustomerDto[]> GetListCustomersAsync(CustomerFilter filter)
        {
            // todo: лучше внедрить пагинацию, НО для упрощения возвращаем всех
            var customers = _customerService
                .GetCustomersQueryable(_dataContext, filter)
                .Select(customer => new CustomerDto
                {
                    IsnNode = customer.IsnNode,
                    IsnCenter = customer.IsnCenter,
                    SurName = customer.SurName,
                    Name = customer.Name,
                    LastName = customer.LastName,
                    Birthday = customer.Birthday
                })
                .ToArray();

            return customers;
        }

        public async Task<InfoCustomerDto> GetInfoCustomerAsync(Guid isnCustomer)
        {
            var customer = _customerService.GetInfoCustomer(_dataContext, isnCustomer);

            return new InfoCustomerDto
            {
                IsnNode = customer.IsnNode,
                IsnCenter = customer.IsnCenter,
                SurName = customer.SurName,
                Name = customer.Name,
                LastName = customer.LastName,
                Birthday = customer.Birthday,
                Center = new CenterDto
                {
                    IsnNode = customer.Center.IsnNode,
                    Name = customer.Center.Name,
                    AddressCity = customer.Center.AddressCity,
                    AddressStreet = customer.Center.AddressStreet,
                    AddressNumberHouse = customer.Center.AddressNumberHouse
                },
                Trainers = customer.CustomerTrainers
                    .Select(customerTrainer => new TrainerDto
                    {
                        IsnNode = customerTrainer.Trainer.IsnNode,
                        SurName = customerTrainer.Trainer.SurName,
                        Name = customerTrainer.Trainer.Name,
                        LastName = customerTrainer.Trainer.LastName,
                        Specialization = customerTrainer.Trainer.Specialization
                    })
                    .ToArray()
            };
        }
    }
}
