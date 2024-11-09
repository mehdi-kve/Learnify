using Abp.Domain.Entities;
using Abp.Extensions;
using Learnify.Courses;
using Learnify.Courses.Dto;
using Learnify.Models.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Utilities;
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
        public async Task Should_Create_New_Course()
        {
            //Prepare for test
            var initialCount = UsingDbContext(context => context.Courses.Count());

            //Run SUT
            await _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "DA001"
                });

            await _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "DA002"
                });

            await _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "DA003"
                });

            //Check results
            UsingDbContext(context =>
            {
                context.Courses.Count().ShouldBe(initialCount + 3);
            });
        }

        [Fact]
        public async Task Should_Not_Create_Course_With_Duplicate_CourseCode()
        {
            //Prepare for test
            var initialTaskCount = UsingDbContext(context => context.Courses.Count());

            //Run SUT
            await _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Software Eng",
                    CourseCode = "SE001"
                });

            var newCourse = await _courseAppService.CreateAsync(
                new Course
                {
                    CourseName = "Datastructure And Algorithms",
                    CourseCode = "SE001"
                });

            //Check results
            UsingDbContext(context =>
            {
                context.Courses.Count().ShouldBe(initialTaskCount + 1);
                newCourse.ShouldBe(null);
            });
        }

        [Fact]
        public async Task Should_Get_All_Courses()
        {
            //Prepare for test
            var initialTaskCount = UsingDbContext(context => context.Courses.Count());

            //Run SUT
            var output = await _courseAppService.GetAllAsync(
                new GetAllCoursesInput
                {
                    Name = null,
                    CourseCode = null
                });

            //Check results

            UsingDbContext(context =>
            {
                context.Courses.Count().ShouldBe(output.Count);
            });
        }

        [Fact]
        public async Task Should_Get_Course_By_Id()
        {
            // Arrange
            var course = await _courseAppService.CreateAsync(new Course
            {
                CourseName = "New Course",
                CourseCode = "NA001"
            });

            // Act
            var result = await _courseAppService.GetByIdAsync(course.Id);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(course.Id);
            result.CourseName.ShouldBe(course.CourseName);
            result.CourseCode.ShouldBe(course.CourseCode);
        }

        [Fact]
        public async Task Should_Not_Get_NonExisting_Course()
        {
            // Arrange
            var nonExistingId = 9999;

            // Act & Assert
            var output = await _courseAppService.GetByIdAsync(nonExistingId);
            output.ShouldBe(null);
        }

        [Fact]
        public async Task Should_Update_Existing_Course()
        {
            // Arrange
            var course = await _courseAppService.CreateAsync(new Course
            {
                CourseName = "Artifictial Intelligence",
                CourseCode = "AI001"
            });

            var updateInput = new Course
            {
                Id = course.Id,
                CourseName = "AI",
                CourseCode = "AI001"
            };

            // Act
            await _courseAppService.UpdateAsync(course.Id, updateInput);

            // Assert
            await UsingDbContext(async context =>
            {
                var updatedCourse = await context.Courses.FindAsync(course.Id);
                updatedCourse.ShouldNotBeNull();
                updatedCourse.CourseName.ShouldBe(updateInput.CourseName);
                updatedCourse.CourseCode.ShouldBe(updateInput.CourseCode);
            });
        }


        [Fact]
        public async Task Should_Not_Update_Course_With_Duplicate_CourseCode()
        {
            // Arrange
            await _courseAppService.CreateAsync(new Course
            {
                CourseName = "Existing Course",
                CourseCode = "EC001"
            });

            var courseToUpdate =
            await _courseAppService.CreateAsync(new Course
            {
                CourseName = "Course to Update",
                CourseCode = "CT001"
            });

            var updateInput = new Course
            {
                Id = courseToUpdate.Id,
                CourseName = "Updated Name",
                CourseCode = "EC001"
            };

            // Act & Assert
            var output = await _courseAppService.UpdateAsync(courseToUpdate.Id, updateInput);
            output.ShouldBe(null);
        }


        [Fact]
        public async Task Should_Not_Update_NonExisting_Course()
        {
            // Arrange
            var updateInput = new Course
            {
                CourseName = "Updated Course",
                CourseCode = "UC001"
            };

            // Act & Assert
            var output = await _courseAppService.UpdateAsync(9999, updateInput);
            output.ShouldBe(null);
        }

        [Fact]
        public async Task Should_Delete_Course()
        {            
            // Arrange
            var initialCount = await UsingDbContext(context => context.Courses.CountAsync());

            await _courseAppService.CreateAsync(new Course
            {
                CourseName = "new course",
                CourseCode = "NA001"
            });

            var course = await _courseAppService.CreateAsync(new Course
            {
                CourseName = "Course to Delete",
                CourseCode = "DL001"
            });

            // Act
            await _courseAppService.DeleteAsync(course.Id);

            // Assert
            await UsingDbContext(async context =>
            {
                context.Courses.Count().ShouldBe(initialCount + 1);
                var deletedCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
                deletedCourse.ShouldBe(null);
            });
        }

        [Fact]
        public async Task Should_Not_Delete_NonExisting_Course()
        {
            // Arrange
            var nonExistingId = 9999;

            // Act & Assert
            var output = await _courseAppService.DeleteAsync(nonExistingId);
            output.ShouldBe(null);
        }
    }
}   
