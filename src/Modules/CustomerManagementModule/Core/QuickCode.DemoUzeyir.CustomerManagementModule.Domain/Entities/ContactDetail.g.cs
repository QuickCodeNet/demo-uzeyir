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

[Table("CONTACT_DETAILS")]
public partial class ContactDetail : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("TYPE", TypeName = "nvarchar(250)")]
	public ContactType Type { get; set; }
	
	[Column("VALUE")]
	[StringLength(250)]
	public string Value { get; set; }
	
	[Column("IS_VERIFIED")]
	public bool IsVerified { get; set; }
	
	[ForeignKey("CustomerId")]
	[InverseProperty(nameof(Customer.ContactDetails))]
	public virtual Customer Customer { get; set; } = null!;

}

