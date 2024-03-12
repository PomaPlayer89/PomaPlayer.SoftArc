using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Logic.Interfaces.Repositories;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Repositories
{
    public class TrainerRepository : IRepository<Trainer>
    {
        public Trainer Create(DataContext dataContext, Trainer model)
        {
            model.IsnNode = Guid.NewGuid();
            dataContext.Trainers.Add(model);

            return model;
        }

        public Trainer Delete(DataContext dataContext, Guid isnNode)
        {
            var trainer = dataContext.Trainers.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Тренера с идентификатором {isnNode} не существует");

            dataContext.Trainers.Remove(trainer);

            return trainer;
        }

        public Trainer GetById(DataContext dataContext, Guid isnNode)
        {
            var trainer = dataContext.Trainers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsnNode == isnNode)
                    ?? throw new Exception($"Тренера с идентификатором {isnNode} не существует");

            return trainer;
        }

        public Trainer Update(DataContext dataContext, Trainer model)
        {
            var trainer = dataContext.Trainers.FirstOrDefault(x => x.IsnNode == model.IsnNode)
                ?? throw new Exception($"Тренера с идентификатором {model.IsnNode} не существует");

            trainer.SurName = model.SurName;
            trainer.Name = model.Name;
            trainer.LastName = model.LastName;
            trainer.Specialization = model.Specialization;

            return trainer;
        }
    }
}
