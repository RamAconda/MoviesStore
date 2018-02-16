using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}