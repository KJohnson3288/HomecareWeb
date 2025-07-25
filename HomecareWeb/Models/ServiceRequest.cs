using System;
using System.ComponentModel.DataAnnotations;

namespace HomecareWeb.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string RequestedService { get; set; }

        public string Notes { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
