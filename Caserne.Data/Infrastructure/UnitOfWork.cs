using Caserne.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private CaserneContext dataContext;
        DatabaseFactory dbFactory;
        
        public UnitOfWork(DatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        
        private ISoldatRepository soldatRepository;
        ISoldatRepository IUnitOfWork.SoldatRepository
        {
            get
            {
                return soldatRepository ?? (soldatRepository = new SoldatRepository(dbFactory));
            }
        }

        private IAvionRepository avionRepository;
        IAvionRepository IUnitOfWork.AvionRepository
        {
            get
            {
                return avionRepository ?? (avionRepository = new  AvionRepository(dbFactory));
            }
        }


        protected CaserneContext DataContext
        {
            get
            {
                return dataContext ?? (dataContext = dbFactory.Get());
            }
        }
        public void Commit()
        {
            DataContext.Commit();
        }
    }

}
