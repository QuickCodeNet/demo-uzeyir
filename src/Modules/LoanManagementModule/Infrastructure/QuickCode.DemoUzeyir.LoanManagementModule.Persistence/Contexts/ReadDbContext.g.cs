using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<LoanApplication> LoanApplication { get; set; }

	public virtual DbSet<LoanProduct> LoanProduct { get; set; }

	public virtual DbSet<Loan> Loan { get; set; }

	public virtual DbSet<RepaymentSchedule> RepaymentSchedule { get; set; }

	public virtual DbSet<LoanPayment> LoanPayment { get; set; }

	public virtual DbSet<Collateral> Collateral { get; set; }

	public virtual DbSet<CollateralType> CollateralType { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<LoanApplication>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'DRAFT'");


		var converterLoanApplicationStatus = new ValueConverter<LoanApplicationStatus, string>(
		v => v.ToString(),
		v => (LoanApplicationStatus)Enum.Parse(typeof(LoanApplicationStatus), v));

		modelBuilder.Entity<LoanApplication>()
		.Property(b => b.Status)
		.HasConversion(converterLoanApplicationStatus);

		modelBuilder.Entity<LoanProduct>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Loan>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'ACTIVE'");


		var converterLoanStatus = new ValueConverter<LoanStatus, string>(
		v => v.ToString(),
		v => (LoanStatus)Enum.Parse(typeof(LoanStatus), v));

		modelBuilder.Entity<Loan>()
		.Property(b => b.Status)
		.HasConversion(converterLoanStatus);

		modelBuilder.Entity<RepaymentSchedule>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'SCHEDULED'");


		var converterRepaymentScheduleStatus = new ValueConverter<PaymentStatus, string>(
		v => v.ToString(),
		v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v));

		modelBuilder.Entity<RepaymentSchedule>()
		.Property(b => b.Status)
		.HasConversion(converterRepaymentScheduleStatus);

		modelBuilder.Entity<CollateralType>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<LoanApplication>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<LoanApplication>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<LoanProduct>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<LoanProduct>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Loan>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Loan>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RepaymentSchedule>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RepaymentSchedule>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<LoanPayment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<LoanPayment>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Collateral>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Collateral>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CollateralType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CollateralType>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<LoanApplication>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<LoanProduct>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Loan>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RepaymentSchedule>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<LoanPayment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Collateral>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CollateralType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<LoanApplication>()
			.HasOne(e => e.LoanProduct)
			.WithMany(p => p.LoanApplications)
			.HasForeignKey(e => e.LoanProductId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Loan>()
			.HasOne(e => e.LoanApplication)
			.WithMany(p => p.Loans)
			.HasForeignKey(e => e.ApplicationId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<RepaymentSchedule>()
			.HasOne(e => e.Loan)
			.WithMany(p => p.RepaymentSchedules)
			.HasForeignKey(e => e.LoanId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<LoanPayment>()
			.HasOne(e => e.Loan)
			.WithMany(p => p.LoanPayments)
			.HasForeignKey(e => e.LoanId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<LoanPayment>()
			.HasOne(e => e.RepaymentSchedule)
			.WithMany(p => p.LoanPayments)
			.HasForeignKey(e => e.ScheduleId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Collateral>()
			.HasOne(e => e.LoanApplication)
			.WithMany(p => p.Collaterals)
			.HasForeignKey(e => e.LoanApplicationId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Collateral>()
			.HasOne(e => e.CollateralType)
			.WithMany(p => p.Collaterals)
			.HasForeignKey(e => e.CollateralTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public override int SaveChanges()
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

}
