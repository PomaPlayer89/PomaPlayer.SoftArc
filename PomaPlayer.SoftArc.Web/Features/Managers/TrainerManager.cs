using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public sealed class TrainerManager : ITrainerManager
    {
        private readonly IMapper _mapper;
        private readonly ITrainerService _trainerService;
        private readonly IRepository<Trainer> _trainerRepository;

        private readonly DataContext _dataContext;

        public TrainerManager(
            IMapper mapper,
            ITrainerService trainerService,
            IRepository<Trainer> trainerRepository,
            DataContext dataContext)
        {
            _mapper = mapper;
            _trainerService = trainerService;
            _trainerRepository = trainerRepository;
            _dataContext = dataContext;
        }

        public async Task CreateTrainerAsync(EditTrainerDto source, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Trainer>(source);

            _trainerRepository.Create(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateTrainerAsync(EditTrainerDto source, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Trainer>(source);

            _trainerRepository.Update(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTrainerAsync(Guid isnTrainer, CancellationToken cancellationToken)
        {
            _trainerRepository.Delete(_dataContext, isnTrainer);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<EditTrainerDto> GetTrainerAsync(Guid isnTrainer)
        {
            var model = _trainerRepository.GetById(_dataContext, isnTrainer);

            return _mapper.Map<EditTrainerDto>(model);
        }

        public async Task SetBindWithCustomerAsync(SetBindWithCustomerDto model, CancellationToken cancellationToken)
        {
            _trainerService.SetBindWithCustomer(_dataContext, model.IsnTrainer, model.IsnCustomer);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteBindWithCustomerAsync(SetBindWithCustomerDto model, CancellationToken cancellationToken)
        {
            _trainerService.DeleteBindWithCustomer(_dataContext, model.IsnTrainer, model.IsnCustomer);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TrainerDto[]> GetListTrainersAsync(TrainerFilter filter)
        {
            // todo: лучше внедрить пагинацию, НО для упрощения возвращаем всех
            var trainers = _trainerService
                .GetTrainersQueryable(_dataContext, filter)
                .Select(trainer => new TrainerDto
                {
                    IsnNode = trainer.IsnNode,
                    SurName = trainer.SurName,
                    Name = trainer.Name,
                    LastName = trainer.LastName,
                    Specialization = trainer.Specialization,
                })
                .ToArray();

            return trainers;
        }

        public async Task<InfoTrainerDto> GetInfoTrainerAsync(Guid isnTrainer)
        {
            var model = _trainerService.GetInfoTrainer(_dataContext, isnTrainer);

            // todo: для Centers, Customers лучше внедрить пагинацию, НО для упрощения возвращаем всех
            return new InfoTrainerDto
            {
                IsnNode = model.IsnNode,
                SurName = model.SurName,
                Name = model.Name,
                LastName = model.LastName,
                Specialization = model.Specialization,
                Centers = model.TrainerCenters
                    .Select(trainerCenter => new CenterDto
                    {
                        IsnNode = trainerCenter.Center.IsnNode,
                        Name = trainerCenter.Center.Name,
                        AddressCity = trainerCenter.Center.AddressCity,
                        AddressStreet = trainerCenter.Center.AddressStreet,
                        AddressNumberHouse = trainerCenter.Center.AddressNumberHouse
                    })
                    .ToArray(),
                Customers = model.TrainerCustomers
                    .Select(trainerCustomer => new CustomerDto
                    {
                        IsnNode = trainerCustomer.Customer.IsnNode,
                        IsnCenter = trainerCustomer.Customer.IsnCenter,
                        SurName = trainerCustomer.Customer.SurName,
                        Name = trainerCustomer.Customer.Name,
                        LastName = trainerCustomer.Customer.LastName,
                        Birthday = trainerCustomer.Customer.Birthday,
                    })
                    .ToArray()
            };
        }

        public async Task<SelectListItem[]> GetCustomersAsync(Guid isnTrainer)
        {
            // todo: лучше внедрить пагинацию, НО для упрощения возвращаем всех
            var customers = _trainerService
                .GetFreeCustomers(_dataContext, isnTrainer)
                .Select(customer => new SelectListItem
                {
                    Value = customer.IsnNode.ToString(),
                    Text = $"{customer.SurName} {customer.Name} {customer.LastName}"
                })
                .OrderBy(x => x.Text)
                .ToArray();

            return customers;
        }

        public async Task<SelectListItem[]> GetListTrainersDropDownAsync(Guid isnCenter)
        {
            // todo: лучше внедрить пагинацию, НО для упрощения возвращаем всех
            var trainers = _trainerService
                .GetFreeTrainers(_dataContext, isnCenter)
                .Select(trainer => new SelectListItem
                {
                    Text = trainer.Specialization + ": " + trainer.SurName + " " + trainer.Name + " " + trainer.LastName,
                    Value = trainer.IsnNode.ToString(),
                })
                .OrderBy(x => x.Text)
                .ToArray();

            return trainers;
        }
    }
}
