namespace DotNetCoreApi.Application.Commands
{
    using DotNetCoreApi.Application.Models;

    using MediatR;

    public class RegisterPaymentCommand : IRequest<PaymentRedirect>
    {
        public RegisterPaymentCommand(
            Payment payment,
            PaymentReference paymentReference)
        {
            this.Payment = payment;
            this.PaymentReference = paymentReference;
        }
        
        public Payment Payment { get; }

        public PaymentReference PaymentReference { get; }
    }
}
