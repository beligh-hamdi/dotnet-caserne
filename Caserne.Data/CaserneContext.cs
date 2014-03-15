using Caserne.Data.Configurations;
using Caserne.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Data
{
    public class CaserneContext : DbContext
    {
        public CaserneContext()
            : base("CaserneConnection")
        {
            Database.SetInitializer<CaserneContext>(new CaserneContextInitializer());
        }

        public DbSet<Soldat> Soldats { get; set; }
        public DbSet<Avion> Avions { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new SoldatConfiguration());

        }

    }

    // public class CaserneContextInitializer : DropCreateDatabaseIfModelChanges<CaserneContext>
    // public class CaserneContextInitializer : CreateDatabaseIfNotExists<CaserneContext> 
    public class CaserneContextInitializer : DropCreateDatabaseAlways<CaserneContext>
    {
        protected override void Seed(CaserneContext context)
        {
            var avion = new List<Avion>{
                new Avion{Constructeur = "ConsMerage", Modele ="C120"},
                new Avion{Constructeur = "ContBoing", Modele ="F16"},
                new Avion{Constructeur = "ContOther", Modele ="F616"}
            };

            avion.ForEach(r => context.Avions.Add(r));   
            context.Commit();

        }

        
        
    }





}

