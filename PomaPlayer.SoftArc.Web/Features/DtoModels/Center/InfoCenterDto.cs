using PomaPlayer.SoftArc.Web.Features.DtoModels.Customer;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer;
using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Center
{
    public sealed record InfoCenterDto
    {
        [Display(Name = "InfoCenterDto_IsnNode", ResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "InfoCenterDto_Name", ResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "InfoCenterDto_AddressCity", ResourceType = typeof(Resource))]
        public string AddressCity { get; init; }

        [Display(Name = "InfoCenterDto_AddressStreet", ResourceType = typeof(Resource))]
        public string AddressStreet { get; init; }

        [Display(Name = "InfoCenterDto_AddressNumberHouse", ResourceType = typeof(Resource))]
        public string AddressNumberHouse { get; init; }

        [Display(Name = "InfoCenterDto_Customers", ResourceType = typeof(Resource))]
        public CustomerDto[] Customers { get; init; }

        [Display(Name = "InfoCenterDto_Trainers", ResourceType = typeof(Resource))]
        public TrainerDto[] Trainers { get; init; }
    }
}
