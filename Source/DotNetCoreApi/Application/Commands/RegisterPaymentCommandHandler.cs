namespace DotNetCoreApi.Application.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using DotNetCoreApi.Application.Models;
    using DotNetCoreApi.Infrastructure.Repositories;
    using DotNetCoreApi.Provider.Query;

    using MediatR;

    public class RegisterPaymentCommandHandler : IRequestHandler<RegisterPaymentCommand, PaymentRedirect>
    {
        private readonly IMediator mediator;

        private readonly IPaymentProviderService paymentProviderService;

        private readonly IPaymentsRepository paymentsRepository;

        public RegisterPaymentCommandHandler(IMediator mediator, IPaymentProviderService paymentProviderService, IPaymentsRepository paymentsRepository)
        {
            this.mediator = mediator;
            this.paymentProviderService = paymentProviderService;
            this.paymentsRepository = paymentsRepository;
        }

        public async Task<PaymentRedirect> Handle(RegisterPaymentCommand request, CancellationToken cancellationToken)
        {
            var redirect = await this.paymentProviderService.Get(request.Payment);
            await this.paymentsRepository.Save(request.PaymentReference, request.Payment);

            return redirect;
        }
    }
}
