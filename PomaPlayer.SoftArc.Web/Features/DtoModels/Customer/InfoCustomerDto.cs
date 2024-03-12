using PomaPlayer.SoftArc.Web.Features.DtoModels.Center;
using PomaPlayer.SoftArc.Web.Features.DtoModels.Trainer;
using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Customer
{
    public class InfoCustomerDto
    {
        [Display(Name = "InfoCustomerDto_IsnNode", ResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "InfoCenterDto_IsnCenter", ResourceType = typeof(Resource))]
        public Guid IsnCenter { get; init; }

        [Display(Name = "InfoCustomerDto_SurName", ResourceType = typeof(Resource))]
        public string SurName { get; init; }

        [Display(Name = "InfoCustomerDto_Name", ResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "InfoCustomerDto_LastName", ResourceType = typeof(Resource))]
        public string LastName { get; init; }

        [Display(Name = "InfoCustomerDto_Birthday", ResourceType = typeof(Resource))]
        public DateTime Birthday { get; init; }

        [Display(Name = "InfoCustomerDto_Center", ResourceType = typeof(Resource))]
        public CenterDto Center { get; init; }

        [Display(Name = "InfoCustomerDto_Trainers", ResourceType = typeof(Resource))]
        public TrainerDto[] Trainers { get; init; }
    }
}
