using Learnify.Assignments;
using Learnify.Dtos.Assignments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentsController : LearnifyControllerBase
    {
        private readonly IAssignmentAppService _assignmentService;

        public AssignmentsController(IAssignmentAppService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        // Teacher: Create Assignment for Course Step
        [HttpPost("upload/{courseStepId:int}")]
        public async Task<IActionResult> CreateAssignment(int courseStepId, [FromBody] AssignmentInput Input)
        {
            var assignment = await _assignmentService.CreateAsync(
                courseStepId, assignmentFile, title, totalScore);
            return Ok(assignment);
        }

        // Get Assignments for Course Step
        /*[HttpGet("{courseStepId}/assignments")]
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> GetAssignments(int courseStepId)
        {
            var assignments = await _assignmentService.GetAssignmentsByCourseStepAsync(courseStepId);
            return Ok(assignments);
        }

        // Student: Submit Assignment Response
        [HttpPost("submit")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> SubmitAssignment(
            [FromQuery] int assignmentId,
            [FromForm] IFormFile submissionFile)
        {
            var submission = await _assignmentService.SubmitAssignmentResponseAsync(
                assignmentId,
                CurrentUser.Id,
                submissionFile);
            return Ok(submission);
        }

        // Student: Get Personal Submissions for Course Step
        [HttpGet("{courseStepId}/submissions")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentSubmissions(int courseStepId)
        {
            var submissions = await _assignmentService.GetStudentSubmissionsForCourseStepAsync(
                courseStepId,
                CurrentUser.Id);
            return Ok(submissions);
        }
    }*/
}
}
