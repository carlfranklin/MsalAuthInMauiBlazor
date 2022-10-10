
using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace MsalAuthInMaui.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
        DataHost = "auth",
        DataScheme = "msal{REPLACE-WITH-YOUR-CLIENT-ID}")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
