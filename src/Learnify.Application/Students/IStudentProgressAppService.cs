using Learnify.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Students
{
    public interface IStudentProgressAppService
    {
        Task InitialProgress(List<StudentProgress> stdInitialProgress);

        Task<StudentProgress?> UpdateProgressAsync(long id, StudentProgress studentProgress);
    }
}
