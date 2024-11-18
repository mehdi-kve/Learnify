using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learnify.Models.Roadmaps;
using Learnify.Models.Students;

namespace Learnify.Models.Roadmaps
{
    [Table("AppRoadmaps")]
    public class Roadmap: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int DurationInDays { get; set; }

        public ICollection<RoadmapCourse> RoadmapCourses { get; set; }
        public ICollection<StudentRoadmap> StudentRoadmaps { get; set; }
    }
}
