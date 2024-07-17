using Microsoft.EntityFrameworkCore;
using StudentManagementSystemAssesment1.Data;
using StudentManagementSystemAssesment1.Models.Domain;

namespace StudentManagementSystemAssesment1.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly SMSDbContext dbContext;

        public SQLStudentRepository(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
           await dbContext.Students.AddAsync(student);
           await dbContext.SaveChangesAsync();
           return student;
        }

        public async Task<Student?> DeleteStudentAsync(Guid id)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudent == null)
            {
                return null;
            }
            dbContext.Students.Remove(existingStudent);
            await dbContext.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<Student?> EditStudentAsync(Guid id, Student student)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(existingStudent == null)
            {
                return null;
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.ContactNumber = student.ContactNumber;
            existingStudent.Email = student.Email;

            await dbContext.SaveChangesAsync();
            return existingStudent;

        }

        public async Task<List<Student>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetByIDAsync(Guid id)
        {
            return await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
