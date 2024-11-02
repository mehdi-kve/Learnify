using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Timing;
using Learnify.Models.Courses;
using Learnify.Models.Enrollments;
using Learnify.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    public class StudentProgressAppService : IStudentProgressAppService, ITransientDependency
    {
        private readonly IRepository<StudentProgress> _studentProgressRepo;

        public StudentProgressAppService(IRepository<StudentProgress> studentProgressRepo)
        {
            _studentProgressRepo = studentProgressRepo;
        }

        public async Task InitialProgress(List<StudentProgress> stdInitialProgress)
        {
            foreach (var stdprogress in stdInitialProgress)
            {
                await _studentProgressRepo.InsertAsync(stdprogress);
            }
        }


        public async Task<StudentProgress> UpdateProgressAsync(int studentId, StudentProgress studentProgress)
        {
            var studentPrg = await _studentProgressRepo.FirstOrDefaultAsync(std => std.Id == studentId);

            if (studentPrg == null)
                return null;

            studentPrg.State = studentProgress.State;
            studentPrg.CompletionDate = studentProgress.CompletionDate;

            return studentPrg;
        }
    }
}
