using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checkpoint4.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Client_ID { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Street Address")]
        public string Street_Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Zip code is required")]
        [StringLength(5, ErrorMessage ="Zip code must be 5 digits")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Phone number must be in the following format (###) ###-####")]
        public string Phone { get; set; }

    }
}