namespace StudentManagementSystemAssesment1.Models.Domain
{
    public class Department
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepatmentHeadName { get; set; }
        public Guid StudentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        
        //navigation property
        public Student Student { get; set; }
    }
}
