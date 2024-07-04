namespace YourNamespace.Models
{
    public class SaleDTO
    {
        public int CustomerID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
