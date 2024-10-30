using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Learnify.Authorization.Roles;
using Learnify.Authorization.Users;
using Learnify.MultiTenancy;
using Learnify.Models.Students;
using Learnify.Models.Enrollments;
using Learnify.Models.Courses;

namespace Learnify.EntityFrameworkCore
{
    public class LearnifyDbContext : AbpZeroDbContext<Tenant, Role, User, LearnifyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseStep> CourseSteps { get; set; }
        public DbSet<StudentProgress> StudentProgresses { get; set; }

        public LearnifyDbContext(DbContextOptions<LearnifyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // student <many_to_many> course #1
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(en => en.Student)
                .HasForeignKey(en => en.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(en => en.Course)
                .HasForeignKey(e => e.CourseId);

            // course <one_to_many> course step #2
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseSteps)
                .WithOne(cs => cs.Course)
                .HasForeignKey(cs => cs.CourseId);

            // student <one_to_many> student progress
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentProgresses)
                .WithOne(sp => sp.Student)
                .HasForeignKey(sp => sp.StudentId);

            //   course step progress <one_to_many> student progress
            modelBuilder.Entity<CourseStep>()
                .HasMany(cs => cs.StudentProgresses)
                .WithOne(en => en.CourseStep)
                .HasForeignKey(cs => cs.CourseStepId);
        }
    }
}
