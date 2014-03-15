using Caserne.Data.Infrastructure;
using Caserne.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Service
{
    public interface IAvionService
    {
        int GetNbAvion();
        IEnumerable<Avion> GetAvions();
        Avion GetAvion(int id);
        void CreateAvion(Avion av);
        void SaveAvion();

        void UpdateAvionDetached(Avion av);
        IEnumerable<Avion> QueryAvions();

        void DeleteAvion(int id);


    }
    public class AvionService : IAvionService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public AvionService()
        {
        }
       
        #region IAvionService Members



        public IEnumerable<Avion> QueryAvions()
        {
            var avions = utOfWork.AvionRepository.GetMany(av => av.Constructeur == "Boing"); //.Take(2);

            return avions;
        }


        public int GetNbAvion()
        {
            var avions = utOfWork.AvionRepository.GetAll().Count();
            return avions;
        }

        public IEnumerable<Avion> GetAvions()
        {
            var avions = utOfWork.AvionRepository.GetAll();
            return avions;
        }

        public Avion GetAvion(int id)
        {
            var avion = utOfWork.AvionRepository.GetById(id);
            return avion;
        }

        public void CreateAvion(Avion av)
        {
            utOfWork.AvionRepository.Add(av);
        }
        public void SaveAvion()
        {
            utOfWork.Commit();
        }

        public void UpdateAvionDetached(Avion av)
        {
            utOfWork.AvionRepository.UpdateAvionDetached(av);
        }

        public void DeleteAvion(int id)
        {
            var avion = utOfWork.AvionRepository.GetById(id);
            utOfWork.AvionRepository.Delete(avion);
        }

 



        #endregion
    }
}
