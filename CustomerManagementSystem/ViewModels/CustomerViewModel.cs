using System.ComponentModel.DataAnnotations;

namespace CustomerManagementSystem.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        // Address Information
        [Display(Name = "Street Address")]
        [StringLength(200)]
        public string? StreetAddress { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? State { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(20)]
        public string? PostalCode { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        [StringLength(200)]
        public string? Occupation { get; set; }

        [StringLength(200)]
        public string? Company { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime? UpdatedAt { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
