using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Logic.Interfaces.Services;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Services
{
    public sealed class TrainerService : ITrainerService
    {
        public void SetBindWithCustomer(DataContext dataContext, Guid isnTrainer, Guid isnCustomer)
        {
            var customer = dataContext.Customers.FirstOrDefault(x => x.IsnNode == isnCustomer)
                ?? throw new Exception($"Клиента с идентификатором {isnCustomer} не существует");

            var trainer = dataContext.Trainers.FirstOrDefault(x => x.IsnNode == isnTrainer)
                ?? throw new Exception($"Тренера с идентификатором {isnTrainer} не существует");

            var trainerCustomer = new TrainerCustomer
            {
                IsnCustomer = customer.IsnNode,
                IsnTrainer = trainer.IsnNode
            };

            dataContext.TrainersCustomers.Add(trainerCustomer);
        }

        public void DeleteBindWithCustomer(DataContext dataContext, Guid isnTrainer, Guid isnCustomer)
        {
            var trainerCustomer = dataContext.TrainersCustomers.FirstOrDefault(x => x.IsnTrainer == isnTrainer && x.IsnCustomer == isnCustomer)
                ?? throw new Exception($"Связи тренера {isnTrainer} c клиентом {isnCustomer} не существует");

            dataContext.TrainersCustomers.Remove(trainerCustomer);
        }

        public IQueryable<Trainer> GetTrainersQueryable(DataContext dataContext, TrainerFilter filter)
        {
            var trainerQuery = dataContext.Trainers
                .AsNoTracking();

            return trainerQuery;
        }

        public Trainer GetInfoTrainer(DataContext dataContext, Guid isnTrainer)
        {
            var trainer = dataContext.Trainers
                .AsNoTracking()
                .Include(x => x.TrainerCenters)
                    .ThenInclude(x => x.Center)
                .Include(x => x.TrainerCustomers)
                    .ThenInclude(x => x.Customer)
                .FirstOrDefault(x => x.IsnNode == isnTrainer)
                    ?? throw new Exception($"Транера с идентификатором {isnTrainer} не существует");

            return trainer;
        }

        public Customer[] GetFreeCustomers(DataContext dataContext, Guid isnTrainer)
        {
            if (!dataContext.Trainers.Any(x => x.IsnNode == isnTrainer))
                throw new Exception($"Транера с идентификатором {isnTrainer} не существует");


            var customers = dataContext.Customers
                .AsNoTracking()
                .Where(c => c.Center.CenterTrainers.Any(ct => ct.IsnTrainer == isnTrainer) &&
                    !dataContext.TrainersCustomers.Any(tc => tc.IsnTrainer == isnTrainer && tc.IsnCustomer == c.IsnNode))
                .ToArray();

            return customers;
        }

        public Trainer[] GetFreeTrainers(DataContext dataContext, Guid isnCenter)
        {
            if (!dataContext.Centers.Any(x => x.IsnNode == isnCenter))
                throw new Exception($"Центра с идентификатором {isnCenter} не существует");

            var trainers = dataContext.Trainers
                .AsNoTracking()
                .Where(t => !dataContext.CentersTrainers.Any(ct => ct.IsnCenter == isnCenter && ct.IsnTrainer == t.IsnNode))
                .ToArray();

            return trainers;
        }
    }
}
