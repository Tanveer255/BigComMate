namespace BigComMate.Entity.Common.Request;

public class OAuthResponse
{
    public string Access_Token { get; set; } // Token to authenticate API requests
    public string Scope { get; set; }        // Scopes granted during installation
    public string User_Id { get; set; }      // BigCommerce user ID
    public string User_Email { get; set; }   // Email of the user who installed the app
    public string Context { get; set; }      // Store hash (e.g., "stores/xyz123")
}

