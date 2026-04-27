using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;

[Table("ACCOUNT_TYPES")]
public partial class AccountType : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CODE")]
	[StringLength(50)]
	public string Code { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("INTEREST_RATE")]
	public decimal InterestRate { get; set; }
	
	[Column("MINIMUM_BALANCE")]
	public decimal MinimumBalance { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Account.AccountType))]
	public virtual ICollection<Account> Accounts { get; } = new List<Account>();

}

