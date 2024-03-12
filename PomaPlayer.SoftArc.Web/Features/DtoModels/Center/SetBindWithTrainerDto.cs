using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Center
{
    // todo: вместо атрибутов валидации можно использовать FluentValidation
    public sealed record SetBindWithTrainerDto
    {
        [Display(Name = "SetBindWithTrainerDto_IsnCenter", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnCenter { get; init; }

        [Display(Name = "SetBindWithTrainerDto_IsnTrainer", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnTrainer { get; init; }
    }
}
