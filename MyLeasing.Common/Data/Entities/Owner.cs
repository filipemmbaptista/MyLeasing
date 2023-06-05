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

        [Display(Name ="Document*")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Document { get; set; }

        [Display(Name = "First Name*")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name*")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }

        [Display(Name ="Fixed Phone")]
        public int? FixedPhone { get; set; }

        [Display(Name ="Cell Phone")]
        public int? CellPhone { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name ="Image")]
        public string ImageUrl { get; set; }

        [Display(Name ="Owner Name")]
        public string OwnerName { get { return $"{FirstName} {LastName}"; } }

        public User User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return null;
                }

                return $"https://localhost:44320{ImageUrl.Substring(1)}";
            }
        }
    }
}
