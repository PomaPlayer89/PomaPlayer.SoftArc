using Microsoft.AspNetCore.Mvc.Rendering;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Center;

namespace PomaPlayer.SoftArc.Web.Features.Interfaces
{
    public interface ICenterManager
    {
        Task CreateCenterAsync(EditCenterDto source, CancellationToken cancellationToken);

        Task UpdateCenterAsync(EditCenterDto source, CancellationToken cancellationToken);

        Task DeleteCenterAsync(Guid isnCenter, CancellationToken cancellationToken);

        Task<EditCenterDto> GetCenterAsync(Guid isnCenter);

        Task SetBindWithTrainerAsync(SetBindWithTrainerDto model, CancellationToken cancellationToken);

        Task DeleteBindWithTrainerAsync(SetBindWithTrainerDto model, CancellationToken cancellationToken);

        Task<InfoCenterDto> GetInfoCenterAsync(Guid isnCenter);

        Task<CenterDto[]> GetListCentersAsync(CenterFilter filter);

        Task<SelectListItem[]> GetListCentersDropDownAsync();
    }
}
