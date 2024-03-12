using AutoMapper;
using PomaPlayer.SoftArc.Storage.Models;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Center;

namespace PomaPlayer.SoftArc.Web.Features.Mappers
{
    public sealed class CenterMapper : Profile
    {
        public CenterMapper()
        {
            CreateMap<CenterDto, Center>();
            CreateMap<Center, CenterDto>();

            CreateMap<EditCenterDto, Center>();
            CreateMap<Center, EditCenterDto>();
        }
    }
}
