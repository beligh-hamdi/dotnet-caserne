using Caserne.Data.Infrastructure;
using Caserne.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Data.Repositories
{
    public class SoldatRepository : RepositoryBase<Soldat>, ISoldatRepository
    {
        public SoldatRepository(DatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }

    public interface ISoldatRepository : IRepository<Soldat>
    {

    }
}
