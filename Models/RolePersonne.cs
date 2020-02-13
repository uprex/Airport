using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport.Models
{
    public class RolePersonne
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<Personne> Personne { get; set; }
    }
}