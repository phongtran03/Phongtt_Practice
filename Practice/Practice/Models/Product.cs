using Practice.Models;

namespace Pratice.Models
{
    public class Product
    {
        public string? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? SupplierID { get; set; }
        public string? CategoryID { get; set; }
        public double QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public double UnitslnStock { get; set; }
        public double UnnitsOnOrder { get; set; }   
        public int  ReorderLevel { get;set; }
        public double Discontinued { get; set; }

       public virtual List<Category>? Categorie { get; set; }
    }
}
