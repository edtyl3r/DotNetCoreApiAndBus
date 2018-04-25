namespace DotNetCoreApi.Infrastructure.Services
{
    using System;
    using System.Threading.Tasks;

    using DotNetCoreApi.Application.Models;
    using DotNetCoreApi.Configuration;
    using DotNetCoreApi.Infrastructure.Notifications;

    using MediatR;

    using Microsoft.Extensions.Options;

    public interface IPaymentProviderService
    {
        Task<PaymentRedirect> Get(Payment payment);
    }

    public class PaymentProviderService : IPaymentProviderService
    {
        private readonly IMediator mediator;

        private readonly PaymentProviderSettings paymentProviderSettings;

        public PaymentProviderService(IMediator mediator, IOptions<PaymentProviderSettings> paymentProviderSettings)
        {
            this.mediator = mediator;
            this.paymentProviderSettings = paymentProviderSettings.Value;
        }

        public Task<PaymentRedirect> Get(Payment payment)
        {
            // In reality, call the provider using the provided settings.
            this.mediator.Publish(new PaymentProviderErrorNotification());
            return Task.FromResult(new PaymentRedirect(new Uri("https://paymentProvider/Redirect")));
        }
    }
}