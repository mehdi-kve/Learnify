using Abp.Application.Services;
using Learnify.Courses;
using Learnify.Courses.Dto;
using Learnify.Dtos.Course;
using Learnify.Enrollments;
using Learnify.Models.Courses;
using Learnify.Models.Students;
using Learnify.Students;
using Learnify.Students.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : LearnifyControllerBase
    {
        private readonly ICourseAppService _courseService;
        private readonly IStudentAppService _studentService;
        private readonly IEnrollmentAppService _enrollmentService;

        public CoursesController(
            ICourseAppService courseAppService, 
            IStudentAppService studentAppService,
            IEnrollmentAppService enrollmentAppService)
        {
            _courseService = courseAppService;
            _studentService = studentAppService;
            _enrollmentService = enrollmentAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses(GetAllCoursesInput input)
        {
            var courses = await _courseService.GetAllAsync(input);

            if (courses == null)
            {
                return NotFound();  
            }

            return Ok(ObjectMapper.Map<List<CourseDto>>(courses));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(ObjectMapper.Map<CourseDto>(course));
        }

        [HttpGet("{courseId:int}/coursesteps")]
        public async Task<IActionResult> GetCourseSteps([FromRoute] int courseId)
        {

            if (await _courseService.GetByIdAsync(courseId) == null)
                return NotFound("Course Not Found");

            var course = await _courseService.GetCourseStepsAsync(courseId);

            if (course == null)
            {
                return NotFound("Course has no steps yet.");
            }

            var courseStepsDto = course.CourseSteps
                .Select(c => ObjectMapper.Map<CourseStepDto>(c)).ToList();

            return Ok(new CourseStepsOutout
            {
                CourseName = course.CourseName,
                CourseCode = course.CourseCode,
                CourseSteps = courseStepsDto            
            });
        }


        [HttpPost("{courseId:int}/enrollstudents")]
        public async Task<IActionResult> EnrollStudents([FromRoute] int courseId, [FromBody] EnrollStudentDto input) 
        {
            var course = await _courseService.GetByIdAsync(courseId);

            if (course == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (input.StudentIds.Count <= 0 || !input.StudentIds.Any())
                return BadRequest();

            foreach (var studentId in input.StudentIds) 
            {
                var student = await _studentService.GetByIdAsync(studentId);

                if (student == null) 
                {
                    return NotFound($"student {studentId} not found!");
                }

                if (await _studentService.ExistingEnrollment(studentId, courseId) == true)
                {
                    continue;
                }

                await _enrollmentService.EnrollStudenstAsync(courseId, studentId);
                // Add CoursSteps to student Progress
            }

            return NoContent();
        }

    }
}
