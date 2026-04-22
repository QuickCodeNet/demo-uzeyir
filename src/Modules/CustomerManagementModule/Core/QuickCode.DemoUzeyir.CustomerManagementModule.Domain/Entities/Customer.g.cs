using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;

[Table("CUSTOMERS")]
public partial class Customer : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_NUMBER")]
	public Guid CustomerNumber { get; set; } = Guid.CreateVersion7();
	
	[Column("FIRST_NAME")]
	[StringLength(250)]
	public string FirstName { get; set; }
	
	[Column("LAST_NAME")]
	[StringLength(250)]
	public string LastName { get; set; }
	
	[Column("DATE_OF_BIRTH")]
	public DateTime DateOfBirth { get; set; }
	
	[Column("CUSTOMER_TYPE_ID")]
	public int CustomerTypeId { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public CustomerStatus Status { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Address.Customer))]
	public virtual ICollection<Address> Addresses { get; } = new List<Address>();


	[InverseProperty(nameof(ContactDetail.Customer))]
	public virtual ICollection<ContactDetail> ContactDetails { get; } = new List<ContactDetail>();


	[InverseProperty(nameof(IdentificationDocument.Customer))]
	public virtual ICollection<IdentificationDocument> IdentificationDocuments { get; } = new List<IdentificationDocument>();


	[InverseProperty(nameof(CustomerRelationship.PrimaryCustomer))]
	public virtual ICollection<CustomerRelationship> CustomerRelationshipPrimaryCustomer { get; } = new List<CustomerRelationship>();


	[InverseProperty(nameof(CustomerRelationship.RelatedCustomer))]
	public virtual ICollection<CustomerRelationship> CustomerRelationshipRelatedCustomer { get; } = new List<CustomerRelationship>();


	[ForeignKey("CustomerTypeId")]
	[InverseProperty(nameof(CustomerType.Customers))]
	public virtual CustomerType CustomerType { get; set; } = null!;

}

