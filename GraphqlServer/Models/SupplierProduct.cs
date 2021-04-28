namespace GraphqlServer.Models
{
    public class SupplierProduct
    
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}