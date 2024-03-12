using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Customer
{
    // todo: вместо атрибутов валидации можно использовать FluentValidation
    public sealed record EditCustomerDto
    {
        [Display(Name = "EditCustomerDto_IsnNode", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "EditCustomerDto_IsnCenter", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnCenter { get; init; }

        [Display(Name = "EditCustomerDto_SurName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string SurName { get; init; }

        [Display(Name = "EditCustomerDto_Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "EditCustomerDto_LastName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string LastName { get; init; }

        [Display(Name = "EditCustomerDto_Birthday", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public DateTime Birthday { get; init; }
    }
}
