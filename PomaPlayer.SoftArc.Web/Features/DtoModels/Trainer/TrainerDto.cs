using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer
{
    public sealed record TrainerDto
    {
        [Display(Name = "TrainerDto_IsnNode", ResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "TrainerDto_SurName", ResourceType = typeof(Resource))]
        public string SurName { get; init; }

        [Display(Name = "TrainerDto_Name", ResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "TrainerDto_LastName", ResourceType = typeof(Resource))]
        public string LastName { get; init; }

        [Display(Name = "TrainerDto_Specialization", ResourceType = typeof(Resource))]
        public string Specialization { get; init; }
    }
}
