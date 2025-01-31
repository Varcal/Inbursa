﻿// <auto-generated />
using Inbursa.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inbursa.Infra.Data.Migrations
{
    [DbContext(typeof(EfDbContext))]
    partial class EfDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inbursa.Domain.Entities.PaymentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("PaymentFlowSummaryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Principal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentFlowSummaryId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("Inbursa.Domain.Entities.PaymentFlowSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("MonthlyPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PropostaId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalInterest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPayment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PaymentFlowSummaries");
                });

            modelBuilder.Entity("Inbursa.Domain.Entities.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AnnualInterestRate")
                        .HasColumnType("decimal(5,4)");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberOfMonths")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("Inbursa.Domain.Entities.PaymentDetail", b =>
                {
                    b.HasOne("Inbursa.Domain.Entities.PaymentFlowSummary", null)
                        .WithMany("PaymentSchedule")
                        .HasForeignKey("PaymentFlowSummaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inbursa.Domain.Entities.PaymentFlowSummary", b =>
                {
                    b.Navigation("PaymentSchedule");
                });
#pragma warning restore 612, 618
        }
    }
}
