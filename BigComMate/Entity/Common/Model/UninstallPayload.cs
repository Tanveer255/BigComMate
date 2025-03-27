namespace BigComMate.Entity.Common.Model;

public class UninstallPayload
{
    public string Store_Hash { get; set; }  // Unique identifier for the store
    public string Client_Id { get; set; }   // App’s client ID
    public string User_Id { get; set; }     // ID of the user who uninstalled the app
}
