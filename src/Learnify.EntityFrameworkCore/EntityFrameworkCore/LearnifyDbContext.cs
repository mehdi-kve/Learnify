using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Learnify.Authorization.Roles;
using Learnify.Authorization.Users;
using Learnify.MultiTenancy;
using Learnify.Students;
using Learnify.Courses;
using Learnify.Enrollments;

namespace Learnify.EntityFrameworkCore
{
    public class LearnifyDbContext : AbpZeroDbContext<Tenant, Role, User, LearnifyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DbSet<Student> students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CourseStep> CourseSteps { get; set; }
        public DbSet<StudentProgress> studentProgresses { get; set; }

        public LearnifyDbContext(DbContextOptions<LearnifyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // student <many_to_many> course
            modelBuilder.Entity<Enrollment>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId});

            modelBuilder.Entity<Enrollment>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.CourseId);

            // course <one_to_many> course step
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseSteps)
                .WithOne(cs => cs.Course)
                .HasForeignKey(cs => cs.CourseId);

            // enrollment <one_to_many> student progress
            modelBuilder.Entity<Enrollment>()
                .HasMany(s => s.StudentProgresses)
                .WithOne(en => en.Enrollment)
                .HasForeignKey(cs => cs.EnrollmentId);


        }
    }
}
