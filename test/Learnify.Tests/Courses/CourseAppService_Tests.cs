using Learnify.Courses;
using Learnify.Courses.Dto;
using Learnify.Models.Courses;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Learnify.Tests.Courses
{
    public class CourseAppService_Tests : LearnifyTestBase
    {
        private readonly ICourseAppService _courseAppService;

        public CourseAppService_Tests()
        {
            _courseAppService = Resolve<ICourseAppService>();
        }

        [Fact]
        public void Should_Create_New_Course()
        {
            //Prepare for test
            var initialTaskCount = UsingDbContext(context => context.Courses.Count());

            //Run SUT
            _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "DA001"
                });

            _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "DA002"
                });

            _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "DA003"
                });

            var CourseShouldBeNull = _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "DA001"
                });

            //Check results
            UsingDbContext(context =>
            {
                context.Courses.Count().ShouldBe(initialTaskCount + 3);
                CourseShouldBeNull.Result.ShouldBe(null);
            });
        }

        [Fact]
        public void Should_Get_Courses()
        {
            //Prepare for test
            var initialTaskCount = UsingDbContext(context => context.Courses.Count());

            //Run SUT
            var output = _courseAppService.GetAllAsync(
                new GetAllCoursesInput
                {
                    Name = null,
                    CourseCode = null
                });

            //Check results

            UsingDbContext(context =>
            {
                context.Courses.Count().ShouldBe(output.Result.Count);
            });
        }
    }
}   
