using Abp.Application.Services;
using Abp.UI;
using Learnify.Courses.Dto;
using Learnify.Models.Students;
using Learnify.Students;
using Learnify.Students.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : LearnifyControllerBase
    {
        private readonly IStudentAppService _studentService;

        public StudentsController(IStudentAppService studentAppService)
        {
            _studentService = studentAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents(GetAllStudentsInput input)
        {
            var students = await _studentService.GetAllAsync(input.Name);

            if (students == null)
            {
                return NotFound();
            }

            return Ok(ObjectMapper.Map<List<StudentOutput>>(students));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(ObjectMapper.Map<StudentOutput>(student));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentInput studentDto)
        {
            if (studentDto == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentMap = ObjectMapper.Map<Student>(studentDto);

            await _studentService.CreateAsync(studentMap);

            return Ok("Student Created Successfully");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentInput updatedStudent)
        {
            if (updatedStudent == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentMap = ObjectMapper.Map<Student>(updatedStudent);

            var result = await _studentService.UpdateAsync(id, studentMap);

            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{studentId:int}/courses")]
        public async Task<IActionResult> GetCourses([FromRoute] int studentId) 
        {

            var student = await _studentService.GetCoursesAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollmentsDto = student.Enrollments
                .Select(enr => new EnrollmentDto
                {
                    CourseId = enr.Id,
                    CourseName = enr.Course.CourseName,
                    EnrollmentDate = enr.CreationTime
                }).ToList();

            return Ok(new StudentCourseOutput
            {
                Name = student.Name,
                Email = student.Email,
                Enrollments = enrollmentsDto
            });

        }

        [HttpGet("{studentId:int}/progress")]
        public async Task<IActionResult> GetProgresses([FromRoute] int studentId)
        {

            var student = await _studentService.GetProgressAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var progressDto = student.StudentProgresses
                .Select(sp => new ProgressDto
                {
                    Id = sp.Id,
                    CourseName = sp.CourseStep.Course.CourseName,
                    CourseStepName = sp.CourseStep.StepName,
                    State = sp.State,
                    CompletionDate = sp.CompletionDate
                }).ToList();


            return Ok(new StudentProgressOutput
            {
                Id = student.Id,
                Name = student.Name,
                StudentProgresses = progressDto
            });

        }

    }
}
