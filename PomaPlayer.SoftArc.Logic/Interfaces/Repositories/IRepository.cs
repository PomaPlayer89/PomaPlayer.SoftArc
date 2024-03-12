using PomaPlayer.SoftArc.Storage.Database;

namespace PomaPlayer.SoftArc.Logic.Interfaces.Repositories
{
    public interface IRepository<TModel>
        where TModel : class
    {
        TModel GetById(DataContext dataContext, Guid isnNode);

        TModel Create(DataContext dataContext, TModel model);

        TModel Update(DataContext dataContext, TModel model);

        TModel Delete(DataContext dataContext, Guid isnNode);
    }
}
