using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer
{
    // todo: вместо атрибутов валидации можно использовать FluentValidation
    public sealed record EditTrainerDto
    {
        [Display(Name = "EditTrainerDto_IsnNode", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "EditTrainerDto_SurName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string SurName { get; init; }

        [Display(Name = "EditTrainerDto_Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "EditTrainerDto_LastName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string LastName { get; init; }

        [Display(Name = "EditTrainerDto_Specialization", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resource))]
        public string Specialization { get; init; }
    }
}
