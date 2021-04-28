namespace GraphqlServer.Queries.Products
{
    public record AddProductInput(
            string name,
            string? description,
            string? uom,
            string? status,
            int brandId,
            int categoryId
        );  
}