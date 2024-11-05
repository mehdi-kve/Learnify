/*using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.UI;
using Learnify.Authorization.Users;
using Learnify.Models.Courses;
using Learnify.Models.Students;
using Learnify.Students.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    public class StudentAppService : IStudentAppService, ITransientDependency
    {
        private readonly IRepository<User> _studentRepo;

        public StudentAppService(IRepository<User> StudnetRepo)
        {
            _studentRepo = StudnetRepo;
        }

        public async Task<List<User>> GetAllAsync(string Name) 
        {
            var students = await _studentRepo.GetAllListAsync();

            if(!Name.IsNullOrWhiteSpace()) 
            {
                students = await _studentRepo.GetAllListAsync(std => std.Name.Contains(Name));

                if (students.Count == 0)
                    return null;
            }
            return students;
        }

        public async Task<User> GetByIdAsync(int id) 
        {
            var student = await _studentRepo.FirstOrDefaultAsync(std => std.Id == id);

            if(student == null)
                return null;

            return student;
        }

        public async Task<User> CreateAsync(User student)
        {
            await _studentRepo.InsertAsync(student);
            return student; 
        }

        public async Task<User> UpdateAsync(long id, Student student) 
        {
            var std = await _studentRepo.FirstOrDefaultAsync(std => std.UserId == id);

            if (std == null)
                return null;

            std.Name = student.Name;
            std.Email = student.Email;
            std.CreationTime = student.CreationTime;

            await _studentRepo.UpdateAsync(std);

            return std;
        }

        public async Task<User> DeleteAsync(long id) 
        {
            var student = await _studentRepo.FirstOrDefaultAsync(std => std.UserId == id);
            if (student == null)
                return null;

            await _studentRepo.DeleteAsync(student);

            return student;
        }

        public async Task<User> GetCoursesAsync(int id)
        {
            var student = await _studentRepo
                .GetAll()
                .Include(std => std.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(std => std.Id == id);

            if (student == null)
                return null;

            return student;

        }

        public async Task<User> GetProgressAsync(int id) 
        {
            var student = await _studentRepo
                .GetAll()
                .Include(std => std.StudentProgresses)
                .ThenInclude(sp => sp.CourseStep)
                .ThenInclude(cs => cs.Course)
                .FirstOrDefaultAsync(std => std.Id == id);

            if (student == null)
                return null;

            return student;
        }

        public async Task<bool> ExistingEnrollment(int studentId, int CourseId)
        {
            bool isEnrolled = false;

            var student = await _studentRepo
                .GetAll()
                .Include(std => std.Enrollments)
                .FirstOrDefaultAsync(std => std.Id == studentId &&
                    std.Enrollments.Any(enr => enr.CourseId == CourseId)
                );

            if (student != null)
                isEnrolled = true;

            return isEnrolled;
        }

    }
}
*/