using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;

[PrimaryKey("AccountId", "CustomerId")]
[Table("ACCOUNT_HOLDERS")]
public partial class AccountHolder : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("ACCOUNT_ID")]
	public int AccountId { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("ROLE")]
	[StringLength(50)]
	public string Role { get; set; }
	
	[ForeignKey("AccountId")]
	[InverseProperty(nameof(Account.AccountHolders))]
	public virtual Account Account { get; set; } = null!;

}

