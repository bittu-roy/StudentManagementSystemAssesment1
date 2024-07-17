using AutoMapper;
using StudentManagementSystemAssesment1.Models.Domain;
using StudentManagementSystemAssesment1.Models.DTO;

namespace StudentManagementSystemAssesment1.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<AddStudentRequestDTO, Student>().ReverseMap();
            CreateMap<UpdateStudentRequestDTO, Student>().ReverseMap();
        }
    }


}
