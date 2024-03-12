using PomaPlayer.SoftArc.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.SoftArc.Web.Features.DtoModels.Customer
{
    public sealed record CustomerDto
    {
        [Display(Name = "CustomerDto_IsnNode", ResourceType = typeof(Resource))]
        public Guid IsnNode { get; init; }

        [Display(Name = "CustomerDto_IsnCenter", ResourceType = typeof(Resource))]
        public Guid IsnCenter { get; init; }

        [Display(Name = "CustomerDto_SurName", ResourceType = typeof(Resource))]
        public string SurName { get; init; }

        [Display(Name = "CustomerDto_Name", ResourceType = typeof(Resource))]
        public string Name { get; init; }

        [Display(Name = "CustomerDto_LastName", ResourceType = typeof(Resource))]
        public string LastName { get; init; }

        [Display(Name = "CustomerDto_Birthday", ResourceType = typeof(Resource))]
        public DateTime Birthday { get; init; }
    }
}
