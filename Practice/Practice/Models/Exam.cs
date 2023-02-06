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
        public virtual List<Student>? Students { get; set;}
        public virtual List<Subject>? Subjects { get; set; }
    }
}
