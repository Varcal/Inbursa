using Inbursa.Application.Contracts;
using Inbursa.Application.Services;
using Inbursa.Domain.Contracts.Repositories;
using Inbursa.Domain.Contracts.Services;
using Inbursa.Domain.Services;
using Inbursa.Domain.Validators;
using Inbursa.Infra.Data.Contexts;
using Inbursa.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Inbursa.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IPaymentFlowSummaryRepository, PaymentFlowSummaryRepository>();
            services.AddScoped<ILoanApplicationService, LoanApplicationService>();
            services.AddScoped<IPropostaValidator, PropostaValidator>();

            services.AddLogging();

            return services;
        }
    }
}
