using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport.Models
{
    public class Personne
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Nom")]
        public string Nom { get; set; }

        [Required]
        [DisplayName("Prenom")]
        public string Prenom { get; set; }

        [DisplayName("Role")]
        public Guid RolePersonneId { get; set; }
        public RolePersonne RolePersonne { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }


    }
}