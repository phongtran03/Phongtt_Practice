namespace Exam.Models
{
    public class Category { 
        public string? CategoryID { get; set; }

        public string?  CategoryName { get; set; }
        public string? Description { get; set;}
        public string? Picture { get; set;}
        public virtual List<Product>? Products { get; set; }
    }
}
