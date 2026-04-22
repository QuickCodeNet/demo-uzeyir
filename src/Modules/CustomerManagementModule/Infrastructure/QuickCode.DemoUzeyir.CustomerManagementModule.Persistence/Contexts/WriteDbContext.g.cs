using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Customer> Customer { get; set; }

	public virtual DbSet<CustomerType> CustomerType { get; set; }

	public virtual DbSet<Address> Address { get; set; }

	public virtual DbSet<ContactDetail> ContactDetail { get; set; }

	public virtual DbSet<IdentificationDocument> IdentificationDocument { get; set; }

	public virtual DbSet<DocumentType> DocumentType { get; set; }

	public virtual DbSet<CustomerRelationship> CustomerRelationship { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Customer>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'PROSPECT'");

		modelBuilder.Entity<Customer>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterCustomerStatus = new ValueConverter<CustomerStatus, string>(
		v => v.ToString(),
		v => (CustomerStatus)Enum.Parse(typeof(CustomerStatus), v));

		modelBuilder.Entity<Customer>()
		.Property(b => b.Status)
		.HasConversion(converterCustomerStatus);

		modelBuilder.Entity<CustomerType>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Address>()
		.Property(b => b.IsPrimary)
		.IsRequired()
		.HasDefaultValue(false);


		var converterAddressType = new ValueConverter<AddressType, string>(
		v => v.ToString(),
		v => (AddressType)Enum.Parse(typeof(AddressType), v));

		modelBuilder.Entity<Address>()
		.Property(b => b.Type)
		.HasConversion(converterAddressType);

		modelBuilder.Entity<ContactDetail>()
		.Property(b => b.IsVerified)
		.IsRequired()
		.HasDefaultValue(false);


		var converterContactDetailType = new ValueConverter<ContactType, string>(
		v => v.ToString(),
		v => (ContactType)Enum.Parse(typeof(ContactType), v));

		modelBuilder.Entity<ContactDetail>()
		.Property(b => b.Type)
		.HasConversion(converterContactDetailType);

		modelBuilder.Entity<IdentificationDocument>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'PENDING_VERIFICATION'");


		var converterIdentificationDocumentStatus = new ValueConverter<DocumentStatus, string>(
		v => v.ToString(),
		v => (DocumentStatus)Enum.Parse(typeof(DocumentStatus), v));

		modelBuilder.Entity<IdentificationDocument>()
		.Property(b => b.Status)
		.HasConversion(converterIdentificationDocumentStatus);

		modelBuilder.Entity<DocumentType>()
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

		modelBuilder.Entity<Customer>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Customer>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CustomerType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CustomerType>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Address>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Address>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ContactDetail>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ContactDetail>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<IdentificationDocument>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<IdentificationDocument>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<DocumentType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<DocumentType>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<CustomerRelationship>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CustomerRelationship>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Customer>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CustomerType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Address>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ContactDetail>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<IdentificationDocument>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<DocumentType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<CustomerRelationship>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Customer>()
			.HasOne(e => e.CustomerType)
			.WithMany(p => p.Customers)
			.HasForeignKey(e => e.CustomerTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Address>()
			.HasOne(e => e.Customer)
			.WithMany(p => p.Addresses)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ContactDetail>()
			.HasOne(e => e.Customer)
			.WithMany(p => p.ContactDetails)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<IdentificationDocument>()
			.HasOne(e => e.Customer)
			.WithMany(p => p.IdentificationDocuments)
			.HasForeignKey(e => e.CustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<IdentificationDocument>()
			.HasOne(e => e.DocumentType)
			.WithMany(p => p.IdentificationDocuments)
			.HasForeignKey(e => e.DocumentTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CustomerRelationship>()
			.HasOne(e => e.PrimaryCustomer)
			.WithMany(p => p.CustomerRelationshipPrimaryCustomer)
			.HasForeignKey(e => e.PrimaryCustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<CustomerRelationship>()
			.HasOne(e => e.RelatedCustomer)
			.WithMany(p => p.CustomerRelationshipRelatedCustomer)
			.HasForeignKey(e => e.RelatedCustomerId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
