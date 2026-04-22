using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<Account> Account { get; set; }

	public virtual DbSet<AccountType> AccountType { get; set; }

	public virtual DbSet<Currency> Currency { get; set; }

	public virtual DbSet<AccountStatement> AccountStatement { get; set; }

	public virtual DbSet<AccountHolder> AccountHolder { get; set; }

	public virtual DbSet<Card> Card { get; set; }

	public virtual DbSet<CardType> CardType { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Account>()
		.Property(b => b.Balance)
		.IsRequired()
		.HasDefaultValueSql("0");

		modelBuilder.Entity<Account>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'PENDING_APPROVAL'");

		modelBuilder.Entity<Account>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterAccountStatus = new ValueConverter<AccountStatus, string>(
		v => v.ToString(),
		v => (AccountStatus)Enum.Parse(typeof(AccountStatus), v));

		modelBuilder.Entity<Account>()
		.Property(b => b.Status)
		.HasConversion(converterAccountStatus);

		modelBuilder.Entity<AccountType>()
		.Property(b => b.InterestRate)
		.IsRequired()
		.HasDefaultValueSql("0");

		modelBuilder.Entity<AccountType>()
		.Property(b => b.MinimumBalance)
		.IsRequired()
		.HasDefaultValueSql("0");

		modelBuilder.Entity<AccountType>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Currency>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AccountStatement>()
		.Property(b => b.Format)
		.IsRequired()
		.HasDefaultValueSql("'PDF'");


		var converterAccountStatementFormat = new ValueConverter<StatementFormat, string>(
		v => v.ToString(),
		v => (StatementFormat)Enum.Parse(typeof(StatementFormat), v));

		modelBuilder.Entity<AccountStatement>()
		.Property(b => b.Format)
		.HasConversion(converterAccountStatementFormat);

		modelBuilder.Entity<Card>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'INACTIVE'");

		modelBuilder.Entity<Card>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterCardStatus = new ValueConverter<CardStatus, string>(
		v => v.ToString(),
		v => (CardStatus)Enum.Parse(typeof(CardStatus), v));

		modelBuilder.Entity<Card>()
		.Property(b => b.Status)
		.HasConversion(converterCardStatus);

		modelBuilder.Entity<CardType>()
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

		modelBuilder.Entity<Account>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Account>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AccountType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AccountType>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Currency>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Currency>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AccountStatement>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AccountStatement>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Card>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Card>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CardType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CardType>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Account>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AccountType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Currency>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AccountStatement>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Card>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CardType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Account>()
			.HasOne(e => e.AccountType)
			.WithMany(p => p.Accounts)
			.HasForeignKey(e => e.AccountTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Account>()
			.HasOne(e => e.Currency)
			.WithMany(p => p.Accounts)
			.HasForeignKey(e => e.CurrencyId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<AccountStatement>()
			.HasOne(e => e.Account)
			.WithMany(p => p.AccountStatements)
			.HasForeignKey(e => e.AccountId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<AccountHolder>()
			.HasOne(e => e.Account)
			.WithMany(p => p.AccountHolders)
			.HasForeignKey(e => e.AccountId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Card>()
			.HasOne(e => e.Account)
			.WithMany(p => p.Cards)
			.HasForeignKey(e => e.AccountId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Card>()
			.HasOne(e => e.CardType)
			.WithMany(p => p.Cards)
			.HasForeignKey(e => e.CardTypeId)
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
