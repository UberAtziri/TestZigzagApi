namespace TestZigzagApi.Models
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }

        public AuthResponse(string accessToken)
        {
            this.AccessToken = accessToken;
        }
    }
}