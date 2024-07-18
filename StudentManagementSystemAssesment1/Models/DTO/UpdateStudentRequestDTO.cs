using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystemAssesment1.Models.DTO
{
    public class UpdateStudentRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "First Name has to be a maximum of 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Last Name has to be a maximum of 100 characters")]
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
    }
}
