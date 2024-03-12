using PomaPlayer.SoftArc.Web.Features.DtoModels.Center;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Customer;
using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer
{
    public sealed record InfoTrainerDto
    {
        [Display(Name = "InfoTrainerDto_IsnNode", ResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "InfoTrainerDto_SurName", ResourceType = typeof(Resource))]
        public string SurName { get; init; }

        [Display(Name = "InfoTrainerDto_Name", ResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "InfoTrainerDto_LastName", ResourceType = typeof(Resource))]
        public string LastName { get; init; }

        [Display(Name = "InfoTrainerDto_Specialization", ResourceType = typeof(Resource))]
        public string Specialization { get; init; }

        [Display(Name = "InfoTrainerDto_Centers", ResourceType = typeof(Resource))]
        public CenterDto[] Centers { get; init; }

        [Display(Name = "InfoTrainerDto_Customers", ResourceType = typeof(Resource))]
        public CustomerDto[] Customers { get; init; }
    }
}
