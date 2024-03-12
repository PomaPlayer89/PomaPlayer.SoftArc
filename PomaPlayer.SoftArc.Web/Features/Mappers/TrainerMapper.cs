using AutoMapper;
using PomaPlayer.SoftArc.Storage.Models;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer;

namespace PomaPlayer.SoftArc.Web.Features.Mappers
{
    public class TrainerMapper : Profile
    {
        public TrainerMapper()
        {
            CreateMap<TrainerDto, Trainer>();
            CreateMap<Trainer, TrainerDto>();

            CreateMap<EditTrainerDto, Trainer>();
            CreateMap<Trainer, EditTrainerDto>();
        }
    }
}
