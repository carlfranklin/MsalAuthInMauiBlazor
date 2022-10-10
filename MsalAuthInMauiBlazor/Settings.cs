namespace MsalAuthInMauiBlazor
{
    public class Settings
    {
        public string ClientId { get; set; }
        public string Tenant { get; set; }
        public string TenantId { get; set; }

        public string InstanceUrl { get; set; }
        public string PolicySignUpSignIn { get; set; }
        public string Authority { get; set; }
        public NestedSettings[] Scopes { get; set; }
        public string ApiUrl { get; set; }
    }
}