using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using XBoxRentals.Models.Validation;

namespace XBoxRentals.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MMM DD YYYY}")]
        [Min18YearsIfAMember]
        [Min13Years]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Subsribe to Email?")]
        public bool IsSubscribedToEmail { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}