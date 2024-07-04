namespace YourNamespace.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
