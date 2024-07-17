using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManagementSystemAssesment1.CustomActionFilters;
using StudentManagementSystemAssesment1.Data;
using StudentManagementSystemAssesment1.Models.Domain;
using StudentManagementSystemAssesment1.Models.DTO;
using StudentManagementSystemAssesment1.Repositories;

namespace StudentManagementSystemAssesment1.Controllers
{
    //httpss;?/localhost:1234/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SMSDbContext dbContext;
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentController(SMSDbContext dbContext, IStudentRepository studentRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }


        //GET ALL STUDENTS
        //GET: /api/students?filterOn= departmentName&filterQuery= Department
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            //Get Data from Database- Domain Models
            var studentsDomain = await studentRepository.GetAllAsync();

            //Map Domain Models to DTOs
            /*var studentsDto = new List<StudentDTO>();
            foreach (var studentDomain in studentsDomain)
            {
                studentsDto.Add(new StudentDTO()
                {
                    Id = studentDomain.Id,
                    FirstName = studentDomain.FirstName,
                    LastName = studentDomain.LastName,
                    ContactNumber = studentDomain.ContactNumber,
                    Email = studentDomain.Email,
                    CreatedOn = studentDomain.CreatedOn,
                    ModifiedOn = studentDomain.ModifiedOn,
                });
            }*/

            //Map Domain Models to DTOs
            //return DTOs
            return Ok(mapper.Map<List<StudentDTO>>(studentsDomain));
        }


        //GET a single student by Id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            //Getting Domain Model from Database
            var studentDomain = await studentRepository.GetByIDAsync(id);
            if (studentDomain == null)
            {
                return NotFound();
            }

            //Mapping Region Domain Model to Region DTO
            /*var studentDTO = new StudentDTO
            {
                Id = studentDomain.Id,
                FirstName = studentDomain.FirstName,
                LastName = studentDomain.LastName,
                ContactNumber = studentDomain.ContactNumber,
                Email = studentDomain.Email,
                CreatedOn = studentDomain.CreatedOn,
                ModifiedOn = studentDomain.ModifiedOn,
            };*/

            //Returning DTO back to the client
            return Ok(mapper.Map<StudentDTO>(studentDomain));
        }


        //Adding a new student
        [HttpPost]
        //Adding CustomActionFilter to validate
        [ValidateModel]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequestDTO addStudentRequestDTO)
        {
            
                //Map or Convert DTO to Domain Model
                var studentDomainModel = mapper.Map<Student>(addStudentRequestDTO);

                //Use Domain Model to Create Region
                studentDomainModel = await studentRepository.AddStudentAsync(studentDomainModel);

                //Map Domain Model back to DTO
                /*var studentDTO = new StudentDTO
                {
                    Id= studentDomainModel.Id,
                    FirstName = studentDomainModel.FirstName,
                    LastName = studentDomainModel.LastName,
                    ContactNumber = studentDomainModel.ContactNumber,
                    Email = studentDomainModel.Email,
                };*/

                var studentDTO = mapper.Map<StudentDTO>(studentDomainModel);

                return CreatedAtAction(nameof(GetByID), new { id = studentDTO.Id }, studentDTO);
           
        }


        //Updating a Student
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> EditStudent([FromRoute] Guid id, [FromBody] UpdateStudentRequestDTO updateStudentRequestDTO)
        {
            //Map DTO to Domain Model
            /*var studentDomainModel = new Student
            {
                FirstName = updateStudentRequestDTO.FirstName,
                LastName = updateStudentRequestDTO.LastName,
                ContactNumber = updateStudentRequestDTO.ContactNumber,
                Email = updateStudentRequestDTO.Email,
            };*/
                var studentDomainModel = mapper.Map<Student>(updateStudentRequestDTO);

                //checking if student exists
                studentDomainModel = await studentRepository.EditStudentAsync(id, studentDomainModel);
                if (studentDomainModel == null)
                {
                    return NotFound();
                }

                //Convert Domain Model to DTO
                /*var studentDTO = new StudentDTO
                {
                    Id = studentDomainModel.Id,
                    FirstName = studentDomainModel.FirstName,
                    LastName = studentDomainModel.LastName,
                    ContactNumber = studentDomainModel.ContactNumber,
                    Email = studentDomainModel.Email,
                };*/


                return Ok(mapper.Map<StudentDTO>(studentDomainModel));
            
        }


        //Deleting a Student
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id, [FromBody] UpdateStudentRequestDTO updateStudentRequestDTO)
        {
            var studentDomainModel = await studentRepository.DeleteStudentAsync(id);
            if (studentDomainModel == null)
            {
                return NotFound();
            }
            //return deleted student back
            //Convert Domain Model to DTO
            /*var studentDTO = new StudentDTO
            {
                Id = studentDomainModel.Id,
                FirstName = studentDomainModel.FirstName,
                LastName = studentDomainModel.LastName,
                ContactNumber = studentDomainModel.ContactNumber,
                Email = studentDomainModel.Email,
            };*/

            return Ok(mapper.Map<StudentDTO>(studentDomainModel));
        }

    }
}
