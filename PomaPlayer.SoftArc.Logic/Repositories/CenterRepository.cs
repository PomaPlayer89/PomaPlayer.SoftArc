using Microsoft.EntityFrameworkCore;
using PomaPlayer.SoftArc.Logic.Interfaces.Repositories;
using PomaPlayer.SoftArc.Storage.Database;
using PomaPlayer.SoftArc.Storage.Models;

namespace PomaPlayer.SoftArc.Logic.Repositories
{
    public class CenterRepository : IRepository<Center>
    {
        public Center Create(DataContext dataContext, Center model)
        {
            model.IsnNode = Guid.NewGuid();
            dataContext.Centers.Add(model);

            return model;
        }

        public Center Delete(DataContext dataContext, Guid isnNode)
        {
            var center = dataContext.Centers.FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Центра с идентификатором {isnNode} не существует");

            dataContext.Centers.Remove(center);

            return center;
        }

        public Center GetById(DataContext dataContext, Guid isnNode)
        {
            var center = dataContext.Centers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsnNode == isnNode)
                    ?? throw new Exception($"Центра с идентификатором {isnNode} не существует");

            return center;
        }

        public Center Update(DataContext dataContext, Center model)
        {
            var center = dataContext.Centers.FirstOrDefault(x => x.IsnNode == model.IsnNode)
                ?? throw new Exception($"Центра с идентификатором {model.IsnNode} не существует");

            center.Name = model.Name;
            center.AddressCity = model.AddressCity;
            center.AddressStreet = model.AddressStreet;
            center.AddressNumberHouse = model.AddressNumberHouse;

            return center;
        }
    }
}
