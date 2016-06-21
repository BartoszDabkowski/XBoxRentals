using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using XBoxRentals.Models;

namespace XBoxRentals.ViewModels
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MMM DD YYYY}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Subsribe to Email?")]
        public bool IsSubscribedToEmail { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string Title => Id != 0 ? "Edit Game" : "New Game";

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            BirthDate = customer.BirthDate;
            IsSubscribedToEmail = customer.IsSubscribedToEmail;
            MembershipTypeId = customer.MembershipTypeId;
        }
    }
}