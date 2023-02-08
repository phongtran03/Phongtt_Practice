using Microsoft.EntityFrameworkCore;

namespace Practice.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 1,
                Name = "nguyen van B",
                DateOfBirth = new DateTime(2001, 04, 20),
                Email = "hoatdfk2001@gmail.com",
                Address = "Nam Dinh"


            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 2,
                Name = "nguyen van A",
                DateOfBirth = new DateTime(2001, 04, 21),
                Email = "hoatdfk2001@gmail.com",
                Address = "Nam Dinh"


            });
            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 3,
                Name = "nguyen van C",
                DateOfBirth = new DateTime(2001, 04, 22),
                Email = "hoatdfk2001@gmail.com",
                Address = "Nam Dinh"


            });
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectId = 1,
                    SubjectName = "C start it program",
                    SubjectCode = "K203",
                    Description = "this is a language",
                    StartDate = new DateTime(2022, 3, 28),
                    EndDate = new DateTime(2023, 1, 28)
                }
                );
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectId = 2,
                    SubjectName = "PHP program",
                    SubjectCode = "K204",
                    Description = "this is a language",
                    StartDate = new DateTime(2022, 3, 28),
                    EndDate = new DateTime(2023, 1, 28)
                }
                );
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectId = 3,
                    SubjectName = "JAVA  program",
                    SubjectCode = "K205",
                    Description = "this is a language",
                    StartDate = new DateTime(2022, 3, 28),
                    EndDate = new DateTime(2023, 1, 28)
                }
                );
            modelBuilder.Entity<Exam>().HasData(
                new Exam
                {
                    ExamId = 1,
                    Score = 5,
                    StudentId = 1,
                    SubjectId = 1
                });
            modelBuilder.Entity<Exam>().HasData(
               new Exam
               {
                   ExamId = 2,
                   Score = 8,
                   StudentId = 2,
                   SubjectId = 2
               });
            modelBuilder.Entity<Exam>().HasData(
               new Exam
               {
                   ExamId = 3,
                   Score = 10,
                   StudentId = 3,
                   SubjectId = 3
               });
        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }    
    }
}
