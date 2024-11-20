using Learnify.Models.Assignments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Assignments
{
    public interface IAssignmentAppService
    {
        Task<Assignment> CreateAsync(int courseStepId,IFormFile assignmentFile,string title,int totalScore);
    }
}
