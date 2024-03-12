using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomaPlayer.SoftArc.Storage.Models
{
    [Index(nameof(IsnCenter), nameof(IsnTrainer))]
    [PrimaryKey(nameof(IsnCenter), nameof(IsnTrainer))]
    public class CenterTrainer
    {
        [ForeignKey(nameof(Center)), Required]
        public Guid IsnCenter { get; set; }

        [ForeignKey(nameof(Trainer)), Required]
        public Guid IsnTrainer { get; set; }

        public virtual Center Center { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
