using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Caserne.Domaine.Entities
{
    public class Avion
    {
        [Key]
        public int Id { get; set; }

        public string Constructeur { get; set; }

        [Required]
        public string Modele { get; set; }
    }
}


