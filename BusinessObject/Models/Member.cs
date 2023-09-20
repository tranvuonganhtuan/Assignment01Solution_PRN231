using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }

        public int MemberId { get; set; }
        public string Email { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }

        // Business rule: Check if email is valid
        public bool IsEmailValid()
        {
            // Implement email validation logic
            // Example: Check if the email is in a valid format
            return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(Email);
        }

        // Business rule: Check if password meets complexity requirements
        public bool IsPasswordValid()
        {
            // Implement password validation logic
            // Example: Check if the password has at least 8 characters
            return !string.IsNullOrWhiteSpace(Password) && Password.Length >= 8;
        }
    }
}
