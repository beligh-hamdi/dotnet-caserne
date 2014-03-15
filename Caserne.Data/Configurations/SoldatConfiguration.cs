using Caserne.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Data.Configurations
{
    public class SoldatConfiguration : EntityTypeConfiguration<Soldat>
    {
        public SoldatConfiguration()
        {

           Map<Fantassin>( f => 
           {
               f.Requires("IsFantassin").HasValue(1);
           })
           .Map<Pilote> ( p =>
           {
               p.Requires("IsFantassin").HasValue(0);
           });




        }
              

    }
}
