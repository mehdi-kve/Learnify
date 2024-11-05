/*using Abp.Application.Services;
using Learnify.Models.Students;
using Learnify.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    public interface IStudentAppService
    {
        Task<List<Student>> GetAllAsync(string? Name);

        Task<Student?> GetByIdAsync(int id);

        Task<Student?> GetCoursesAsync(int id);

        Task<Student?> GetProgressAsync(int id);

        Task<Student> CreateAsync(Student student);

        Task<Student?> UpdateAsync(long id, Student student);

        Task<Student?> DeleteAsync(long id);

        Task<bool> ExistingEnrollment(int StudentId, int CourseId);
    }
}
*/