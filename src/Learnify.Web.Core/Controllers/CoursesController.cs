using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Learnify.Authorization;
using Learnify.Authorization.Users;
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
        private readonly IEnrollmentAppService _enrollmentService;
        private readonly IStudentProgressAppService _studentProgressService;
        private readonly ICourseStepAppService _courseStepService;
        private readonly IRepository<User, long> _userRepo;

        public CoursesController(
            IRepository<User, long> userRepository,
            ICourseAppService courseAppService,
            IEnrollmentAppService enrollmentAppService,
            IStudentProgressAppService studentProgressService,
            ICourseStepAppService courseStepService)
        {
            _courseService = courseAppService;
            _enrollmentService = enrollmentAppService;
            _studentProgressService = studentProgressService;
            _courseStepService = courseStepService;
            _userRepo = userRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Student)]
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

        [AbpAuthorize(PermissionNames.Pages_Student)]
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

        [AbpAuthorize(PermissionNames.Pages_Users)]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var csMap = ObjectMapper.Map<Course>(input);
            var course = _courseService.CreateAsync(csMap);
            return Ok("Course Created Successfully");
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseInput input)
        {
            if (input == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var csMap = ObjectMapper.Map<Course>(input);

            var result = await _courseService.UpdateAsync(id, csMap);

            if (result == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [AbpAuthorize(PermissionNames.Pages_Users)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.DeleteAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [AbpAuthorize(PermissionNames.Pages_Student)]
        [HttpPost("{courseId:int}/enrollstudents")]
        public async Task<IActionResult> EnrollStudents([FromRoute] int courseId, [FromBody] EnrollStudentDto input) 
        {
            var course = await _courseService.GetByIdAsync(courseId);

            if (course == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (input.UserIds.Count <= 0 || !input.UserIds.Any())
                return BadRequest();

            foreach (var studentId in input.UserIds) 
            {
                var student = await _userRepo.FirstOrDefaultAsync(u => u.Id == studentId);
                if (student == null) 
                {
                    return NotFound($"student {studentId} not found!");
                }

                if (await _enrollmentService.ExistingEnrollment(studentId, courseId) == true)
                {
                    continue;
                }

                await _enrollmentService.EnrollStudenstAsync(studentId, courseId);
                var cs = await _courseStepService.GetCourseStepsAsync(courseId);

                if (cs != null) 
                {
                    var stdInitialProgress = cs
                        .Select(c => new StudentProgress
                        {
                            CourseStepId = c.Id,
                            UserId = studentId
                        }).ToList();

                    await _studentProgressService.InitialProgress(stdInitialProgress);
                }
            }

            return NoContent();
        }

    }
}
