using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomaPlayer.SoftArc.Storage.Models
{
    [Index(nameof(IsnTrainer), nameof(IsnCustomer))]
    [PrimaryKey(nameof(IsnTrainer), nameof(IsnCustomer))]
    public class TrainerCustomer
    {
        [ForeignKey(nameof(Trainer)), Required]
        public Guid IsnTrainer { get; set; }

        [ForeignKey(nameof(Customer)), Required]
        public Guid IsnCustomer { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
