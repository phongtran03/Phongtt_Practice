namespace Product_API.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Code { get; set; } = "";
        public string? Name { get; set; } = "";
        public Decimal Price { get; set; } = 0;
        public int Amount { get; set; } = 0;
        public string? Unit { get; set; } = ""; 
    }
}
