using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Timing;
using Learnify.Courses;
using Learnify.Models.Courses;
using Learnify.Models.Enrollments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Enrollments
{
    public class EnrollmentAppService : IEnrollmentAppService, ITransientDependency
    {
        private readonly IRepository<Enrollment, int> _enrollmentsRepo;

        public EnrollmentAppService(IRepository<Enrollment, int> enrollmentRepo)
        {
            _enrollmentsRepo = enrollmentRepo;
        }

        public async Task EnrollStudenstAsync(long userId, int courseId)
        {
            await _enrollmentsRepo.InsertAsync(new Enrollment
            {
                CourseId = courseId,
                UserId = userId,
                CreationTime = Clock.Now
            });
        }

        public async Task<bool> ExistingEnrollment(long userId, int CourseId)
        {
            bool isEnrolled = false;

            var studentEnr = await _enrollmentsRepo
                .FirstOrDefaultAsync(e => e.UserId == userId && e.CourseId == CourseId);

            if (studentEnr != null)
                isEnrolled = true;

            return isEnrolled;
        }
    }
}
