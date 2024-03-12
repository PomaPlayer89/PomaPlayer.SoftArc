using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomaPlayer.SoftArc.Storage.Models
{
    [Index(nameof(Name))]
    public class Center
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string AddressCity { get; set; }

        [Required, MaxLength(100)]
        public string AddressStreet { get; set; }

        [Required, MaxLength(10)]
        public string AddressNumberHouse { get; set; }

        [InverseProperty(nameof(Customer.Center))]
        public virtual ICollection<Customer> Customers { get; set; }

        [InverseProperty(nameof(CenterTrainer.Center))]
        public virtual ICollection<CenterTrainer> CenterTrainers { get; set; }
    }
}
