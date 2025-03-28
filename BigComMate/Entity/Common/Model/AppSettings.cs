namespace BigComMate.Entity.Common.Model;

public class AppSettings
{
    public BigCommerceSettings BigCommerceSettings { get; set; }
}
public class BigCommerceSettings
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string RedirectUri { get; set; }
    public string AuthUrl { get; set; }
    public string TokenUrl { get; set; }
}