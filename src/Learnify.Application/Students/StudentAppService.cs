using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
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
        private readonly IRepository<Student> _studentRepo;

        public StudentAppService(IRepository<Student> StudnetRepo)
        {
            _studentRepo = StudnetRepo;
        }

        public async Task<List<Student>> GetAllAsync(string Name) 
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

        public async Task<Student> GetByIdAsync(int id) 
        {
            var student = await _studentRepo.FirstOrDefaultAsync(std => std.Id == id);

            if(student == null)
                return null;

            return student;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _studentRepo.InsertAsync(student);
            return student;
        }

        public async Task<Student> UpdateAsync(int id, Student student) 
        {
            var std = await _studentRepo.FirstOrDefaultAsync(std => std.Id == id);

            if (std == null)
                return null;

            std.Name = student.Name;
            student.Email = student.Email;
            return std;
        }

        public async Task<Student> DeleteAsync(int id) 
        {
            var student = await _studentRepo.FirstOrDefaultAsync(std => std.Id == id);
            if (student == null)
                return null;

            await _studentRepo.DeleteAsync(student);

            return student;
        }

        public async Task<Student> GetCoursesAsync(int id)
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

        public async Task<Student> GetProgressAsync(int id) 
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

        // TODO: Impl
        public Task<Student> UpdateProgressAync(int id, Student student)
        {
            throw new NotImplementedException();
        }

    }
}
