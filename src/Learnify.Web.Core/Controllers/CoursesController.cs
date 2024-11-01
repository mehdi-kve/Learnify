using Abp.Application.Services;
using Learnify.Courses;
using Learnify.Courses.Dto;
using Learnify.Models.Courses;
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

        public CoursesController(ICourseAppService courseAppService)
        {
            _courseService = courseAppService;
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


        /*
        // api Endpoint => Post: api/courses/{courseId}/enrollstudents
        public async void EnrollStudenstAsync(int courseId, EnrollStudentDto input)
        {
            var course = await _courseRepo.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
                throw new UserFriendlyException("No Course Found!");

            if (input.StudentIds.Count <= 0 || !input.StudentIds.Any())
            {
                throw new UserFriendlyException("Student IDs cannot be empty!");
            }
            
            foreach (var studentId in input.StudentIds)
            {
                var student = await _studentRepo.FirstOrDefaultAsync(c => c.Id == studentId);

                if (student != null)
                {
                    course.Enrollments.Add(new Enrollment
                    {
                        CourseId = courseId,
                        StudentId = studentId
                    });

                    await _courseRepo.UpdateAsync(course);
                }
            }
        }
         */
    }
}
