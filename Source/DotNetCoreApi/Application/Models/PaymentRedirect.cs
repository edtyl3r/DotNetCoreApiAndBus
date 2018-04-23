namespace DotNetCoreApi.Application.Models
{
    using System;

    public class PaymentRedirect
    {
        public PaymentRedirect()
        {
        }

        public PaymentRedirect(Uri redirectUri)
        {
            this.RedirectUri = redirectUri ?? throw new ArgumentNullException(nameof(redirectUri));
        }

        public Uri RedirectUri { get; set; }
    }
}