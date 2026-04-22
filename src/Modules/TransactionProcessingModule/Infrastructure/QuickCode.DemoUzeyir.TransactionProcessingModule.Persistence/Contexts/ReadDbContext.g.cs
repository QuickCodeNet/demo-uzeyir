using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<Transaction> Transaction { get; set; }

	public virtual DbSet<TransactionType> TransactionType { get; set; }

	public virtual DbSet<TransactionChannel> TransactionChannel { get; set; }

	public virtual DbSet<PendingTransfer> PendingTransfer { get; set; }

	public virtual DbSet<Beneficiary> Beneficiary { get; set; }

	public virtual DbSet<TransactionFee> TransactionFee { get; set; }

	public virtual DbSet<FeeType> FeeType { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Transaction>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'PENDING'");


		var converterTransactionStatus = new ValueConverter<TransactionStatus, string>(
		v => v.ToString(),
		v => (TransactionStatus)Enum.Parse(typeof(TransactionStatus), v));

		modelBuilder.Entity<Transaction>()
		.Property(b => b.Status)
		.HasConversion(converterTransactionStatus);

		modelBuilder.Entity<TransactionType>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<TransactionChannel>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<PendingTransfer>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'SCHEDULED'");


		var converterPendingTransferStatus = new ValueConverter<TransferStatus, string>(
		v => v.ToString(),
		v => (TransferStatus)Enum.Parse(typeof(TransferStatus), v));

		modelBuilder.Entity<PendingTransfer>()
		.Property(b => b.Status)
		.HasConversion(converterPendingTransferStatus);

		modelBuilder.Entity<Beneficiary>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterBeneficiaryType = new ValueConverter<BeneficiaryType, string>(
		v => v.ToString(),
		v => (BeneficiaryType)Enum.Parse(typeof(BeneficiaryType), v));

		modelBuilder.Entity<Beneficiary>()
		.Property(b => b.Type)
		.HasConversion(converterBeneficiaryType);

		modelBuilder.Entity<FeeType>()
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

		modelBuilder.Entity<Transaction>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Transaction>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TransactionType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TransactionType>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TransactionChannel>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TransactionChannel>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<PendingTransfer>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<PendingTransfer>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Beneficiary>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Beneficiary>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TransactionFee>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TransactionFee>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<FeeType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<FeeType>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Transaction>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TransactionType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TransactionChannel>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<PendingTransfer>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Beneficiary>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TransactionFee>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<FeeType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Transaction>()
			.HasOne(e => e.TransactionType)
			.WithMany(p => p.Transactions)
			.HasForeignKey(e => e.TransactionTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Transaction>()
			.HasOne(e => e.TransactionChannel)
			.WithMany(p => p.Transactions)
			.HasForeignKey(e => e.TransactionChannelId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<PendingTransfer>()
			.HasOne(e => e.Beneficiary)
			.WithMany(p => p.PendingTransfers)
			.HasForeignKey(e => e.BeneficiaryId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TransactionFee>()
			.HasOne(e => e.Transaction)
			.WithMany(p => p.TransactionFees)
			.HasForeignKey(e => e.TransactionId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TransactionFee>()
			.HasOne(e => e.FeeType)
			.WithMany(p => p.TransactionFees)
			.HasForeignKey(e => e.FeeTypeId)
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
