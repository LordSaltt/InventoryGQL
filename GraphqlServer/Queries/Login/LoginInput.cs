namespace GraphqlServer.Queries.Login
{

     public record LoginInput
    (
        string? UserName,
        string? Password
    );   
}