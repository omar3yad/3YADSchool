using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITISchool.Models
{
    public class ITISchoolContext :IdentityDbContext<ApplicationUser>
    {
        public ITISchoolContext() : base()
        { }
        public ITISchoolContext(DbContextOptions options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITISchool;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.instructors)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(i => i.CrsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Trainee>()
                .HasOne(t => t.Department)
                .WithMany(d => d.trainees)
                .HasForeignKey(t => t.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.courses)
                .HasForeignKey(c => c.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CrsResult>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CrsResults)
                .HasForeignKey(cr => cr.CrsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CrsResult>()
                .HasOne(cr => cr.Trainee)
                .WithMany(t => t.CrsResults)
                .HasForeignKey(cr => cr.TraineeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}