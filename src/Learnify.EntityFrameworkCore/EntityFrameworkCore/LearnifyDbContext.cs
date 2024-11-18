using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Learnify.Authorization.Roles;
using Learnify.Authorization.Users;
using Learnify.MultiTenancy;
using Learnify.Models.Students;
using Learnify.Models.Enrollments;
using Learnify.Models.Courses;
using Learnify.Models.Assignments;
using Learnify.Models.Roadmaps;

namespace Learnify.EntityFrameworkCore
{
    public class LearnifyDbContext : AbpZeroDbContext<Tenant, Role, User, LearnifyDbContext>
    {
        /* Define a DbSet for each entity of the application */        
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseStep> CourseSteps { get; set; }
        public DbSet<StudentProgress> StudentProgresses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<RoadmapCourse> RoadmapCourses { get; set; }
        public DbSet<StudentRoadmap> StudentRoadmaps { get; set; }

        public LearnifyDbContext(DbContextOptions<LearnifyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // student <many_to_many> course #1
            modelBuilder.Entity<User>()
                .HasMany(s => s.Enrollments)
                .WithOne(en => en.User)
                .HasForeignKey(en => en.UserId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(en => en.Course)
                .HasForeignKey(e => e.CourseId);

            // student <many_to_many> Roadmap #1
            modelBuilder.Entity<User>()
                .HasMany(s => s.StudentRoadmaps)
                .WithOne(en => en.User)
                .HasForeignKey(en => en.UserId);

            modelBuilder.Entity<Roadmap>()
                .HasMany(r => r.StudentRoadmaps)
                .WithOne(sr => sr.Roadmap)
                .HasForeignKey(sr => sr.RoadmapId);

            // Roadmap <many_to_many> course #3
            modelBuilder.Entity<Roadmap>()
                .HasMany(r => r.RoadmapCourses)
                .WithOne(rc => rc.Roadmap)
                .HasForeignKey(r => r.RoadmapId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.RoadmapCourses)
                .WithOne(rc => rc.Course)
                .HasForeignKey(rc => rc.CourseId);

            // course <one_to_many> course step
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseSteps)
                .WithOne(cs => cs.Course)
                .HasForeignKey(cs => cs.CourseId);

            // student <one_to_many> student progress
            modelBuilder.Entity<User>()
                .HasMany(s => s.StudentProgresses)
                .WithOne(sp => sp.User)
                .HasForeignKey(sp => sp.UserId);

            //   course step <one_to_many> student progress
            modelBuilder.Entity<CourseStep>()
                .HasMany(cs => cs.StudentProgresses)
                .WithOne(en => en.CourseStep)
                .HasForeignKey(cs => cs.CourseStepId);

            // course step <one_to_many> Assignment
            modelBuilder.Entity<CourseStep>()
                .HasMany(cs => cs.Assignments)
                .WithOne(a => a.CourseStep)
                .HasForeignKey(a => a.CourseStepId);

            // Student Progress <one_to_many> Response
            modelBuilder.Entity<StudentProgress>()
                .HasMany(sp => sp.Responses)
                .WithOne(r => r.StudentProgress)
                .HasForeignKey(r => r.StudentProgressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
