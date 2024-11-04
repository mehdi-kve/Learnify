using Abp.Application.Services;
using Abp.Authorization;
using Learnify.Authorization;
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
    [AbpAuthorize(PermissionNames.Pages_Student_ViewStudentPage)]
    public class CoursesController : LearnifyControllerBase
    {
        private readonly ICourseAppService _courseService;
        private readonly IStudentAppService _studentService;
        private readonly IEnrollmentAppService _enrollmentService;
        private readonly IStudentProgressAppService _studentProgressService;
        private readonly ICourseStepAppService _courseStepService;

        public CoursesController(
            ICourseAppService courseAppService,
            IStudentAppService studentAppService,
            IEnrollmentAppService enrollmentAppService,
            IStudentProgressAppService studentProgressService,
            ICourseStepAppService courseStepService)
        {
            _courseService = courseAppService;
            _studentService = studentAppService;
            _enrollmentService = enrollmentAppService;
            _studentProgressService = studentProgressService;
            _courseStepService = courseStepService;
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
            var course = await _courseService.GetByIdAsync(courseId);

            if (course == null)
                return NotFound("Course Not Found");

            var courseStp = await _courseStepService.GetCourseStepsAsync(courseId);

            if (courseStp == null)
            {
                return NotFound("Course has no steps yet.");
            }

            var courseStepsDto = courseStp
                .Select(c => ObjectMapper.Map<CourseStepDto>(c)).ToList();

            return Ok(new CourseStepsOutout
            {
                CourseName = course.CourseName,
                CourseCode = course.CourseCode,
                CourseSteps = courseStepsDto
            });
        }

        [HttpPost("{courseId:int}/coursestep")]
        public async Task<IActionResult> CreateCourseStep([FromRoute] int courseId, [FromBody] courseStepInput input)
        {
            var course = _courseService.GetByIdAsync(courseId);

            if (course == null)
                return NotFound("Course Not Found");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var csMap = ObjectMapper.Map<CourseStep>(input);
            csMap.CourseId = courseId;

            await _courseStepService.CreateAsync(csMap);

            return Ok("Coursestep Created Successfully");
        }

        [HttpPut("{courseStepId:int}/coursestep")]
        public async Task<IActionResult> UpdateStudent([FromRoute]int courseStepId, [FromBody] courseStepInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var csMap = ObjectMapper.Map<CourseStep>(input);

            var result = await _courseStepService.UpdateAsync(courseStepId, csMap);

            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{courseStepId:int}/coursestep")]
        public async Task<IActionResult> DeleteStudent(int courseStepId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseStepService.DeleteAsync(courseStepId);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
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
                var cs = await _courseStepService.GetCourseStepsAsync(courseId);

                if (cs != null) 
                {
                    var stdInitialProgress = cs
                        .Select(c => new StudentProgress
                        {
                            CourseStepId = c.Id,
                            StudentId = studentId
                        }).ToList();

                    await _studentProgressService.InitialProgress(stdInitialProgress);
                }
            }

            return NoContent();
        }

    }
}
