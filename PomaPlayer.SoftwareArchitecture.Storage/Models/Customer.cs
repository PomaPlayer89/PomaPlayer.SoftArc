using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomaPlayer.SoftArc.Storage.Models
{
    [Index(nameof(IsnCenter), nameof(SurName), nameof(Name), nameof(LastName))]
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [ForeignKey(nameof(Center))]
        public Guid IsnCenter { get; set; }

        [Required, MaxLength(100)]
        public string SurName { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public DateTime Birthday { get; set; }

        public virtual Center Center { get; set; }

        [InverseProperty(nameof(TrainerCustomer.Customer))]
        public virtual ICollection<TrainerCustomer> CustomerTrainers { get; set; }
    }
}
