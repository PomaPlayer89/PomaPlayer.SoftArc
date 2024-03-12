using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer
{
    // todo: вместо атрибутов валидации можно использовать FluentValidation
    public sealed record SetBindWithCustomerDto
    {
        [Display(Name = "SetBindWithCustomerDto_IsnTrainer", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnTrainer { get; init; }

        [Display(Name = "SetBindWithCustomerDto_IsnCustomer", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnCustomer { get; init; }
    }
}
