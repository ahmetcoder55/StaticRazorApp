namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public String Category { get; set; }

        public String? ImageUrl { get; set; }
        public int Stock { get; set; }
    }
}