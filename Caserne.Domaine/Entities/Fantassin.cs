using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caserne.Domaine.Entities
{
    public class Fantassin : Soldat
    {
        [Required]
        public string Arme { get; set; }

        [Range(0, 100)]
        public int NbMunition { get; set; }
    }
}
