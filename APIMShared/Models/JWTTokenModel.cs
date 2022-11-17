namespace APIMShared.Models
{
    public class JWTTokenModel
    {
        public string tokenType { get; set; }
        public long expiresIn { get; set; }
        public long extExpiresIn { get; set; }
        public string accessToken { get; set; }
    }
}