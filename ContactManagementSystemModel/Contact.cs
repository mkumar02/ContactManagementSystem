using System.ComponentModel.DataAnnotations;

namespace ContactManagementSystemModel
{
    public class Contact
    {
        public int Id { get; set; }

        [Required, StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Job Title")]
        public string? JobTitle { get; set; }

        public string? Company { get; set; }

        public string? Address { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Last Contacted Date")]
        [DataType(DataType.Date)]
        public DateTime? LastContactedDate { get; set; }

        [StringLength(5000, ErrorMessage = "Comments cannot be longer than 5000 characters")]
        public string? Comments { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }
}
