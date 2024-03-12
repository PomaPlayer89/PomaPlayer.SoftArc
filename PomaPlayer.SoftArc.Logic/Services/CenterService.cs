using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Logic.DtoModels;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Logic.Interfaces.Services;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Services
{
    public sealed class CenterService : ICenterService
    {
        public void SetBindWithTrainer(DataContext dataContext, Guid isnCenter, Guid isnTrainer)
        {
            var center = dataContext.Centers.FirstOrDefault(x => x.IsnNode == isnCenter)
                ?? throw new Exception($"Центра с идентификатором {isnCenter} не существует");

            var trainer = dataContext.Trainers.FirstOrDefault(x => x.IsnNode == isnTrainer)
                ?? throw new Exception($"Тренера с идентификатором {isnTrainer} не существует");

            var centerTrainer = new CenterTrainer
            {
                IsnCenter = isnCenter,
                IsnTrainer = isnTrainer
            };

            dataContext.CentersTrainers.Add(centerTrainer);
        }

        public void DeleteBindWithTrainer(DataContext dataContext, Guid isnCenter, Guid isnTrainer)
        {
            var centerTrainer = dataContext.CentersTrainers.FirstOrDefault(x => x.IsnCenter == isnCenter && x.IsnTrainer == isnTrainer)
                ?? throw new Exception($"Связи центра {isnCenter} с тренером не существует {isnTrainer}");

            dataContext.CentersTrainers.Remove(centerTrainer);
        }

        public IQueryable<Center> GetCentersQueryable(DataContext dataContext, CenterFilter filter)
        {
            var centerQuery = dataContext.Centers
                .AsNoTracking();

            return centerQuery;
        }

        public Center GetInfoCenter(DataContext dataContext, Guid isnCenter)
        {
            var center = dataContext.Centers
                .AsNoTracking()
                .Include(x => x.Customers)
                .Include(x => x.CenterTrainers)
                    .ThenInclude(x => x.Trainer)
                .FirstOrDefault(x => x.IsnNode == isnCenter)
                    ?? throw new Exception($"Центра с идентификатором {isnCenter} не существует");

            return center;
        }

        public DropDownItemDto[] GetListCentersDropDown(DataContext dataContext)
        {
            var centers = dataContext.Centers
                .AsNoTracking()
                .Select(center => new DropDownItemDto
                {
                    Label = center.Name,
                    Value = center.IsnNode.ToString(),
                })
                .ToArray();

            return centers;
        }
    }
}
