using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses;

public class CustomerInfo
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(20, ErrorMessage = "First name may not include more than 20 characters")]
    public string FirstName { get; set; }


    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name may not include more than 50 characters")]
    public string LastName { get; set; }


    [Required(ErrorMessage = "Adress is required.")]
    [StringLength(100, ErrorMessage = "The Adress may not include more than 50 characters")]
    public string Address { get; set; }


    [Required(ErrorMessage = "City is required.")]
    [StringLength(100, ErrorMessage = "The city may not include more than 50 characters")]
    public string City { get; set; }


    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    [StringLength(20, ErrorMessage = "Phonenumber may not include more than 20 characters.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email.")]
    public string Email { get; set; }
}
