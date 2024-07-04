namespace YourNamespace.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Summary { get; set; }
        public int CategoryID { get; set; }
        //public Category Category { get; set; }
    }
}
