using StudentManagementSystemAssesment1.Models.Domain;

namespace StudentManagementSystemAssesment1.Repositories
{
    public interface IStudentRepository
    {
       
        Task<List<Student>>GetAllAsync(string? filterOn= null, string? filterQuery = null);
        Task<Student?> GetByIDAsync(Guid id);
        Task<Student> AddStudentAsync(Student student);
        Task<Student?> EditStudentAsync(Guid id, Student student);
        Task<Student?> DeleteStudentAsync(Guid id);
    }
}
