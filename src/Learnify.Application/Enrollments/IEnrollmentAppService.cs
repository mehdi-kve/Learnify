using Abp.Timing;
using Learnify.Models.Enrollments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Enrollments
{
    public interface IEnrollmentAppService
    {
        Task EnrollStudenstAsync(long UserId, int courseId);
        Task<bool> ExistingEnrollment(long UserId, int courseId);
    }
}
