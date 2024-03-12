using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Center
{
    // todo: вместо атрибутов валидации можно использовать FluentValidation
    public sealed record EditCenterDto
    {
        [Display(Name = "EditCenterDto_IsnNode", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "EditCenterDto_Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "EditCenterDto_AddressCity", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string AddressCity { get; init; }

        [Display(Name = "EditCenterDto_AddressStreet", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string AddressStreet { get; init; }

        [Display(Name = "EditCenterDto_AddressNumberHouse", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string AddressNumberHouse { get; init; }
    }
}
