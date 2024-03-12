using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Center
{
    public sealed record CenterDto
    {
        [Display(Name = "CenterDto_IsnNode", ResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "CenterDto_Name", ResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "CenterDto_AddressCity", ResourceType = typeof(Resource))]
        public string AddressCity { get; init; }

        [Display(Name = "CenterDto_AddressStreet", ResourceType = typeof(Resource))]
        public string AddressStreet { get; init; }

        [Display(Name = "CenterDto_AddressNumberHouse", ResourceType = typeof(Resource))]
        public string AddressNumberHouse { get; init; }
    }
}
