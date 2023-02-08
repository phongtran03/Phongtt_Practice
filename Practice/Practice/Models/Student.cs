using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Student
    {
        public long  StudentId { get; set; }
        [Required]
        [StringLength(150,MinimumLength =8)]
        public string? Name { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Address { get; set; }
        public virtual List<Exam>? Exam { get; set; }
    }
}
