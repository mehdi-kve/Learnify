using Abp.BlobStoring;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Learnify.Models.Assignments;
using Learnify.Models.Courses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Assignments
{
    public class AssignmentAppService : IAssignmentAppService, ITransientDependency
    {
        private readonly IBlobContainer _blobContainer;
        private readonly IRepository<Assignment> _assignmentRepository;
        private readonly IRepository<Response> _submissionRepository;
        private readonly IRepository<CourseStep> _courseStepRepository;

        public async Task<Assignment> CreateAsync(int courseStepId, IFormFile assignmentFile, string title, int totalScore)
        {
            // Validate course step exists
            var courseStep = await _courseStepRepository.GetAsync(courseStepId);

            // Save file to blob storage
            using var stream = assignmentFile.OpenReadStream();
            string blobName = $"{Guid.NewGuid()}_{assignmentFile.FileName}";
            await _blobContainer.SaveAsync(blobName, stream);

            // Create assignment entity
            var assignment = new Assignment
            {
                CourseStepId = courseStepId,
                Title = title,
                TotalScore = totalScore,
                FileName = assignmentFile.FileName,
                FilePath = blobName,
                FileSize = assignmentFile.Length,
                ContentType = assignmentFile.ContentType
            };

            return await _assignmentRepository.InsertAsync(assignment);
        }
    }
}
