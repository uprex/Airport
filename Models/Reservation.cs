using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport.Models
{
    public class Reservation
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Depart")]
        public string depart { get; set; }

        [Required]
        [DisplayName("Destination")]
        public string Destination { get; set; }

        /* [Required]
         [DisplayName("Avion")]
         public Guid AvionId { get; set; }
         public NomAvion NomAvion { get; set; }*/

        public virtual ICollection<Personne> Personnes { get; set; }


    }
}