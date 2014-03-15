using Caserne.Data.Infrastructure;
using Caserne.Domaine.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Caserne.Data.Repositories
{
    public class AvionRepository : RepositoryBase<Avion>, IAvionRepository
    {
        public AvionRepository(DatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }

        public void UpdateAvionDetached(Avion av)
        {
                  
            Avion existing = this.DataContext.Avions.Find(av.Id);

            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);

            this.DataContext.Entry(av).State = EntityState.Modified;
        }

       

    }

    public interface IAvionRepository : IRepository<Avion>
    {
        void UpdateAvionDetached(Avion av);
       
    }
}
