namespace Auth
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userId, string password);
    }
}
