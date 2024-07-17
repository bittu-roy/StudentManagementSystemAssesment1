namespace SMSAssessment1.UI.Model.DTO
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public string DepartmentName { get; set; }
    }
}
