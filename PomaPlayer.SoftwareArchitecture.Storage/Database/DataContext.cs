using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Storage.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Center> Centers { get; set; }

        public virtual DbSet<Trainer> Trainers { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CenterTrainer> CentersTrainers { get; set; }

        public virtual DbSet<TrainerCustomer> TrainersCustomers { get; set; }
    }
}
