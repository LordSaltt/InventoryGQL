namespace GraphqlServer.Queries.SupplierProducts
{
    public record AddSupplierProductInput
    (
        int productId,
        int supplierId
    );
}