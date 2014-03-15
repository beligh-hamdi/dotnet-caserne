using Caserne.Data.Infrastructure;
using Caserne.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Service
{
    public interface ISoldatService
    {
        void SaveSoldat();
        void CreateFantassin(Fantassin f);
        void CreatePilote(Pilote p);
        IEnumerable<Soldat> GetSoldats();
        IEnumerable<Pilote> GetPilotes();
        IEnumerable<Fantassin> GetFantassins();
    }
    
    public class SoldatService : ISoldatService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public SoldatService()
        {

        }
        
        #region ISoldatService Members

        public IEnumerable<Soldat> GetSoldats()
        {
            return utOfWork.SoldatRepository.GetAll();
        }

        public  IEnumerable<Pilote> GetPilotes()
        {
            return utOfWork.SoldatRepository.GetAll().OfType<Pilote>(); 
        }
        public IEnumerable<Fantassin> GetFantassins()
        {
            return utOfWork.SoldatRepository.GetAll().OfType<Fantassin>(); 
        }


        public void CreateFantassin(Fantassin f)
        {
            utOfWork.SoldatRepository.Add(f);
        }

        public void CreatePilote(Pilote p)
        {
            utOfWork.SoldatRepository.Add(p);
        }

        public void SaveSoldat()
        {
            utOfWork.Commit();
        }
        #endregion
    }
}

