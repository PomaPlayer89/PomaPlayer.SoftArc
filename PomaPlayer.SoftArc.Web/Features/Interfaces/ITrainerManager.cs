using Microsoft.AspNetCore.Mvc.Rendering;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer;

namespace PomaPlayer.SoftArc.Web.Features.Interfaces
{
    public interface ITrainerManager
    {
        Task CreateTrainerAsync(EditTrainerDto source, CancellationToken cancellationToken);

        Task UpdateTrainerAsync(EditTrainerDto source, CancellationToken cancellationToken);

        Task DeleteTrainerAsync(Guid isnTrainer, CancellationToken cancellationToken);

        Task<EditTrainerDto> GetTrainerAsync(Guid isnTrainer);

        Task SetBindWithCustomerAsync(SetBindWithCustomerDto model, CancellationToken cancellationToken);

        Task DeleteBindWithCustomerAsync(SetBindWithCustomerDto model, CancellationToken cancellationToken);

        Task<TrainerDto[]> GetListTrainersAsync(TrainerFilter filter);

        Task<InfoTrainerDto> GetInfoTrainerAsync(Guid isnTrainer);

        Task<SelectListItem[]> GetCustomersAsync(Guid isnTrainer);

        Task<SelectListItem[]> GetListTrainersDropDownAsync(Guid isnCenter);
    }
}
