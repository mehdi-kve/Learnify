using Abp.Domain.Entities;
using Learnify.Models.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Models.Roadmaps
{
    [Table("AppRoadmapCourses")]
    public class RoadmapCourse: Entity
    {
        public int Order { get; set; }

        [ForeignKey("RoadmapId")]
        public virtual int RoadmapId { get; set; }
        public virtual Roadmap Roadmap { get; set; }

        [ForeignKey("CourseId")]
        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}
