namespace GraphqlServer.Queries.Suppliers
{
    public record AddSupplierInput
    (
        int id,
        string? name,
        string? address,
        string? phone,
        string? contact,
        string? email,
        string? comments        
    );
}