using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Interfaces.Services
{
    public interface ITrainerService
    {
        void SetBindWithCustomer(DataContext dataContext, Guid isnTrainer, Guid isnCustomer);

        void DeleteBindWithCustomer(DataContext dataContext, Guid isnTrainer, Guid isnCustomer);

        IQueryable<Trainer> GetTrainersQueryable(DataContext dataContext, TrainerFilter filter);

        Trainer GetInfoTrainer(DataContext dataContext, Guid isnTrainer);

        Customer[] GetFreeCustomers(DataContext dataContext, Guid isnTrainer);

        Trainer[] GetFreeTrainers(DataContext dataContext, Guid isnCenter);
    }
}
