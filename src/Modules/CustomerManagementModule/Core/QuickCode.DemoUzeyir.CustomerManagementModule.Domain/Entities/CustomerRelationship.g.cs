using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;

[Table("CUSTOMER_RELATIONSHIPS")]
public partial class CustomerRelationship : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PRIMARY_CUSTOMER_ID")]
	public int PrimaryCustomerId { get; set; }
	
	[Column("RELATED_CUSTOMER_ID")]
	public int RelatedCustomerId { get; set; }
	
	[Column("RELATIONSHIP_TYPE")]
	[StringLength(50)]
	public string RelationshipType { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[ForeignKey("PrimaryCustomerId")]
	[InverseProperty(nameof(Customer.CustomerRelationshipPrimaryCustomer))]
	public virtual Customer PrimaryCustomer { get; set; } = null!;


	[ForeignKey("RelatedCustomerId")]
	[InverseProperty(nameof(Customer.CustomerRelationshipRelatedCustomer))]
	public virtual Customer RelatedCustomer { get; set; } = null!;

}

