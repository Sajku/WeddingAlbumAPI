namespace WeddingAlbum.Common.Auth
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(string id, string role);
    }
}
