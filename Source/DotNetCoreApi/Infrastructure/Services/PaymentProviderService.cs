namespace DotNetCoreApi.Provider.Query
{
    using System;
    using System.Threading.Tasks;
    using Configuration;

    using DotNetCoreApi.Application.Models;

    using Microsoft.Extensions.Options;

    public interface IPaymentProviderService
    {
        Task<PaymentRedirect> Get(Payment payment);
    }

    public class PaymentProviderService : IPaymentProviderService
    {
        private readonly PaymentProviderSettings paymentProviderSettings;

        public PaymentProviderService(IOptions<PaymentProviderSettings> paymentProviderSettings)
        {
            this.paymentProviderSettings = paymentProviderSettings.Value;
        }

        public Task<PaymentRedirect> Get(Payment payment)
        {
            // In reality, call the provider using the provided settings.
            return Task.FromResult(new PaymentRedirect(new Uri("https://paymentProvider/Redirect")));
        }
    }
}