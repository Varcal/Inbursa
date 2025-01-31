using Inbursa.Domain.Entities;
using Inbursa.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace Inbursa.Infra.Data.Contexts
{
    public class EfDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<PaymentFlowSummary> PaymentFlowSummaries { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        public EfDbContext(DbContextOptions<EfDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProposalMapping());
            modelBuilder.ApplyConfiguration(new PaymentFlowSummaryMapping());
            modelBuilder.ApplyConfiguration(new PaymentDetailMapping());
        }
    }
}
