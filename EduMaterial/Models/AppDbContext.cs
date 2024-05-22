using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EduMaterial.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, String>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<InstructorCourse> InstructorCourses { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<CourseProducer> CourseProducers { get; set; }

        // Ara tablo: Kategoriler ve Eğitimler arasındaki ilişki Temsili
        public DbSet<CategoryCourse> CategoryCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // IdentityDbContext için gerekli olan ilişkileri ayarlamak için base sınıfının OnModelCreating metodu çağrılır

            modelBuilder.Entity<InstructorCourse>()
                .HasKey(ic => new { ic.InstructorId, ic.CourseId });

            //modelBuilder.Entity<InstructorCourse>()
            //    .HasOne(ic => ic.Instructor)
            //    .WithMany(i => i.Courses) // Courses özelliği koleksiyon olarak tanımlanmış olmalı
            //    .HasForeignKey(ic => ic.InstructorId);

            //modelBuilder.Entity<InstructorCourse>()
            //    .HasOne(ic => ic.Course)
            //    .WithMany(c => c.Instructors)
            //    .HasForeignKey(ic => ic.CourseId);

            modelBuilder.Entity<CourseTag>()
                .HasKey(ct => new { ct.CourseId, ct.TagId });

            //modelBuilder.Entity<CourseTag>()
            //    .HasOne(ct => ct.Course)
            //    .WithMany(c => c.Tags)
            //    .HasForeignKey(ct => ct.CourseId);

            //modelBuilder.Entity<CourseTag>()
            //    .HasOne(ct => ct.Tag)
            //    .WithMany(c => c.CourseTags)
            //    .HasForeignKey(ct => ct.TagId);

            modelBuilder.Entity<CourseProducer>()
                .HasKey(cp => new { cp.CourseId, cp.ProducerId });

            //modelBuilder.Entity<CourseProducer>()
            //    .HasOne(cp => cp.Course)
            //    .WithMany(c => c.CourseProducers)
            //    .HasForeignKey(cp => cp.CourseId);

            //modelBuilder.Entity<CourseProducer>()
            //    .HasOne(cp => cp.Producer)
            //    .WithMany(p => p.CourseProducers)
            //    .HasForeignKey(cp => cp.ProducerId);

            modelBuilder.Entity<CategoryCourse>()
        .HasKey(cc => new { cc.CategoryId, cc.CourseId });

            //modelBuilder.Entity<CategoryCourse>()
            //    .HasOne(cc => cc.Category)
            //    .WithMany(c => c.CategoryCourses)
            //    .HasForeignKey(cc => cc.CategoryId);

            //modelBuilder.Entity<CategoryCourse>()
            //    .HasOne(cc => cc.Course)
            //    .WithMany(c => c.CategoryCourses)
            //    .HasForeignKey(cc => cc.CourseId);

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
        );

          
            // Seed Admin User
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                
                UserName = "admin@example.com",
                FullName = "Admin",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Qwr1Ty.?!"),
                SecurityStamp = string.Empty
            });           

        }


    }
}
