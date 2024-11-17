using Abp.Domain.Entities;
using Learnify.Models.Enrollments;
using Learnify.Models.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learnify.Authorization.Users;
using Learnify.Models.Assignments;

namespace Learnify.Models.Students
{
    [Table("AppStudentProgresses")]
    public class StudentProgress : Entity
    {
        public ProgressState State { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int TotalScore {  get; set; }    

        [ForeignKey("UserId")]
        public virtual long UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("CourseStep")]
        public virtual int CourseStepId { get; set; }
        public virtual CourseStep CourseStep { get; set; }

        public ICollection<Response> Responses { get; set; }

        public StudentProgress()
        {
            State = ProgressState.InProgress;
        }
    }
}
