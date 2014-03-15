
using Caserne.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        ISoldatRepository SoldatRepository { get; }
        IAvionRepository AvionRepository { get; }
    }
}
