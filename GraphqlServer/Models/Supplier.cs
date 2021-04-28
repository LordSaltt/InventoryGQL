using System.Collections.Generic;

namespace GraphqlServer.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Comments { get; set; }

        public ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();

    }
}