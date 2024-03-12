using PomaPlayer.SoftArc.Logic.DtoModels;
using PomaPlayer.SoftArc.Logic.DtoModels.Filters;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Interfaces.Services
{
    public interface ICenterService
    {
        void SetBindWithTrainer(DataContext dataContext, Guid isnCenter, Guid isnTrainer);

        void DeleteBindWithTrainer(DataContext dataContext, Guid isnCenter, Guid isnTrainer);

        IQueryable<Center> GetCentersQueryable(DataContext dataContext, CenterFilter filter);

        Center GetInfoCenter(DataContext dataContext, Guid isnCenter);

        DropDownItemDto[] GetListCentersDropDown(DataContext dataContext);

    }
}
