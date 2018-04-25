namespace DotNetCoreApi.Infrastructure.Notifications
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.ApplicationInsights;

    public class PaymentProviderErrorHandler : INotificationHandler<PaymentProviderErrorNotification>
    {
        private readonly TelemetryClient telemetryClient;

        public PaymentProviderErrorHandler()
        {
            this.telemetryClient = new TelemetryClient();
        }

        public Task Handle(PaymentProviderErrorNotification notification, CancellationToken cancellationToken)
        {
           this.telemetryClient.TrackTrace("Payment provider rejected the payment");
           return Task.CompletedTask;
        }
    }
}
