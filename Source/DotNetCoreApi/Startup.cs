namespace DotNetCoreApi
{
    using Configuration;

    using DotNetCoreApi.Infrastructure.Repositories;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Provider.Query;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            PaymentProviderSettings foo = new PaymentProviderSettings();
            this.Configuration.BindOrThrow("PaymentProvider", foo);

            services.Configure<DocumentDbSettings>(settings => { this.Configuration.BindOrThrow("DocumentDB", settings); } );
            services.Configure<PaymentProviderSettings>(settings => { this.Configuration.BindOrThrow("PaymentProvider", settings); } );

            services.AddMediatR();

            services.AddSingleton<IPaymentProviderService, PaymentProviderService>()
                .AddSingleton<IPaymentsRepository, PaymentsRepository>()
                .AddSingleton<IDocumentClientFactory, DocumentClientFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
