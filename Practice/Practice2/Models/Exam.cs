using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Exam
    {
        public long ExamId { get; set; }
        [Required]
        [Range(0, 10)]
        public int Score { get; set; }
        public long StudentId { get; set; }
        public int  SubjectId { get; set; }
        public virtual List<Student>? Student { get; set;}
        public virtual List<Subject>? Subject { get; set; }
    }
}
