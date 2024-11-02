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
        Task EnrollStudenstAsync(int courseId, int studentId);
    }
}
