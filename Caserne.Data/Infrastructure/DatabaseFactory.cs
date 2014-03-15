using Caserne.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Data.Infrastructure
{
    public class DatabaseFactory: Disposable,IDatabaseFactory
    {

        private CaserneContext dataContext = null;
        public CaserneContext Get()
        {
            return dataContext ?? (dataContext = new CaserneContext());
        }
        protected override void DisposeCore()
        {
            if (
                dataContext != null)
                dataContext.Dispose();
        }
    }
}
