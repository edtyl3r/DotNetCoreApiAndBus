namespace DotNetCoreApi.Infrastructure.Repositories
{
    using System.Threading.Tasks;

    using DotNetCoreApi.Application.Models;
    using DotNetCoreApi.Configuration;

    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Extensions.Options;

    public interface IPaymentsRepository
    {
        Task Save(PaymentReference paymentReference, Payment payment);
    }

    internal class PaymentsRepository : IPaymentsRepository
    {
        private readonly IDocumentClient documentClientFactory;
        private readonly DocumentDbSettings settings;

        public PaymentsRepository(IDocumentClientFactory documentClientFactory, IOptions<DocumentDbSettings> settings)
        {
            this.settings = settings.Value;
            this.documentClientFactory = documentClientFactory.Create(this.settings).Result;
        }

        public Task Save(PaymentReference paymentReference, Payment payment)
        {
            var documentUri = UriFactory.CreateDocumentCollectionUri(this.settings.DatabaseId, this.settings.CollectionId);
            return this.documentClientFactory.CreateDocumentAsync(documentUri, payment);
        }
    }
}
