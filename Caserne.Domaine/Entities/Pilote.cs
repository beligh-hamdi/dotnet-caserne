using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Domaine.Entities
{
    public class Pilote : Soldat
    {
        [Required]
        public int AvionId { get; set; }

        public virtual Avion Avion { get; set; }

 
        [Range(0, 100)]
        public int NbHeuresDeVol { get; set; }

    
    }
}
