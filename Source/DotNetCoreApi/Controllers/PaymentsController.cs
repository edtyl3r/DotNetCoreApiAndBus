namespace DotNetCoreApi.Controllers
{
    using System.Threading.Tasks;

    using DotNetCoreApi.Application.Commands;
    using DotNetCoreApi.Application.Models;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IMediator mediator;

        public PaymentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public Payment Get(string id)
        {
            return new Payment();
        }

        [HttpPut("{paymentReference}")]
        public async Task<CreatedAtActionResult> Put(string paymentReference, [FromBody]Payment payment)
        {
            var command = new RegisterPaymentCommand(payment, new PaymentReference(paymentReference));
            var redirect = await this.mediator.Send(command);
            return this.CreatedAtAction("Get", new { id = paymentReference }, redirect);
        }
    }
}
