namespace GraphqlServer.Queries.Login
{

     public record LoginInput
    (
        string? Email,
        string? Password
    );   
}