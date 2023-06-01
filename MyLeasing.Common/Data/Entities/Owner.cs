using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data.Entities
{
    public class Owner : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Document*")]
        public int Document { get; set; }

        [Required]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [Display(Name ="Fixed Phone")]
        public int? FixedPhone { get; set; }

        [Display(Name ="Cell Phone")]
        public int? CellPhone { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get { return $"{FirstName} {LastName}"; } }
    }
}
