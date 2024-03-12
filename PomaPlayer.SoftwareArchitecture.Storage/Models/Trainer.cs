using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomaPlayer.SoftArc.Storage.Models
{
    [Index(nameof(SurName), nameof(Name), nameof(LastName))]
    public class Trainer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required, MaxLength(100)]
        public string SurName { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string Specialization { get; set; }

        [InverseProperty(nameof(CenterTrainer.Trainer))]
        public virtual ICollection<CenterTrainer> TrainerCenters { get; set; }

        [InverseProperty(nameof(TrainerCustomer.Trainer))]
        public virtual ICollection<TrainerCustomer> TrainerCustomers { get; set; }
    }
}
