using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphqlServer.Models
{
    public class Product
    {
        public int Id { get; set; }        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UOM { get; set; }
        public string? Status { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<SupplierProduct> SuplierProducts { get; set; } = new List<SupplierProduct>();
    }
}