using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemAssesment1.Models.DTO
{
    public class AddStudentRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage ="First Name has to be a maximum of 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "First Name has to be a maximum of 100 characters")]
        public string LastName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
