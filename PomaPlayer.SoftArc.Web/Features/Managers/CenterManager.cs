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
    public class CenterManager : ICenterManager
    {
        private readonly IMapper _mapper;
        private readonly ICenterService _centerService;
        private readonly IRepository<Center> _centerRepository;

        private readonly DataContext _dataContext;

        public CenterManager(
            IMapper mapper,
            ICenterService centerService,
            IRepository<Center> centerRepository,
            DataContext dataContext)
        {
            _mapper = mapper;
            _centerService = centerService;
            _centerRepository = centerRepository;
            _dataContext = dataContext;
        }

        public async Task CreateCenterAsync(EditCenterDto source, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Center>(source);

            _centerRepository.Create(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCenterAsync(EditCenterDto source, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Center>(source);

            _centerRepository.Update(_dataContext, model);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCenterAsync(Guid isnCenter, CancellationToken cancellationToken)
        {
            _centerRepository.Delete(_dataContext, isnCenter);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<EditCenterDto> GetCenterAsync(Guid isnCenter)
        {
            var model = _centerRepository.GetById(_dataContext, isnCenter);

            return _mapper.Map<EditCenterDto>(model);
        }

        public async Task SetBindWithTrainerAsync(SetBindWithTrainerDto model, CancellationToken cancellationToken)
        {
            _centerService.SetBindWithTrainer(_dataContext, model.IsnCenter, model.IsnTrainer);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteBindWithTrainerAsync(SetBindWithTrainerDto model, CancellationToken cancellationToken)
        {
            _centerService.DeleteBindWithTrainer(_dataContext, model.IsnCenter, model.IsnTrainer);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<InfoCenterDto> GetInfoCenterAsync(Guid isnCenter)
        {
            var center = _centerService.GetInfoCenter(_dataContext, isnCenter);

            // todo: для Customers, Trainers лучше внедрить пагинацию, НО для упрощения возвращаем всех
            return new InfoCenterDto
            {
                IsnNode = center.IsnNode,
                Name = center.Name,
                AddressCity = center.AddressCity,
                AddressStreet = center.AddressStreet,
                AddressNumberHouse = center.AddressNumberHouse,
                Customers = center.Customers
                    .Select(customer => new CustomerDto
                    {
                        IsnNode = customer.IsnNode,
                        IsnCenter = customer.IsnCenter,
                        SurName = customer.SurName,
                        Name = customer.Name,
                        LastName = customer.LastName,
                        Birthday = customer.Birthday
                    })
                    .ToArray(),
                Trainers = center.CenterTrainers
                    .Select(centerTrainer => new TrainerDto
                    {
                        IsnNode = centerTrainer.Trainer.IsnNode,
                        SurName = centerTrainer.Trainer.SurName,
                        Name = centerTrainer.Trainer.Name,
                        LastName = centerTrainer.Trainer.LastName,
                        Specialization = centerTrainer.Trainer.Specialization
                    })
                    .ToArray()
            };
        }

        public async Task<CenterDto[]> GetListCentersAsync(CenterFilter filter)
        {
            // todo: лучше внедрить пагинацию, НО для упрощения возвращаем всех
            var centers = _centerService
                .GetCentersQueryable(_dataContext, filter)
                .Select(x => new CenterDto
                {
                    IsnNode = x.IsnNode,
                    Name = x.Name,
                    AddressCity = x.AddressCity,
                    AddressStreet = x.AddressStreet,
                    AddressNumberHouse = x.AddressNumberHouse,
                })
                .ToArray();

            return centers;
        }

        public async Task<SelectListItem[]> GetListCentersDropDownAsync()
        {
            // todo: лучше внедрить пагинацию, НО для упрощения возвращаем всех
            var centers = _centerService.GetListCentersDropDown(_dataContext)
                .Select(center => new SelectListItem
                {
                    Text = center.Label,
                    Value = center.Value,
                })
                .ToArray();

            return centers;
        }
    }
}
