using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Restaurant.Web.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsRegistered { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "First name")]
        public string rFirstName { get; set; }

        [Display(Name = "Last name")]
        public string rLastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string rUserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string rAddressLine1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string rAddressLine2 { get; set; }

        [DataType(DataType.Text)]
        public string rAddressLine3 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Postcode")]
        public string rPostcode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Phone number")]
        public string rPhoneNumber { get; set; }
    }

    public class OneOffUserModel
    {
        [Required]
        [Display(Name = "First name")]
        public string exFirstName { get; set; }

        [Display(Name = "Last name")]
        public string exLastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Email Address cannot be longer than 50 characters.")]
        [Display(Name = "Email Address")]
        public string exUserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Delivery address")]
        public string exAddressLine1 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string exAddressLine2 { get; set; }

        [DataType(DataType.Text)]
        public string exAddressLine3 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Postcode")]
        public string exPostcode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Contact number")]
        public string exPhoneNumber { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
