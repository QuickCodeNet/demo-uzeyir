using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;

[Table("ACCOUNTS")]
public partial class Account : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ACCOUNT_NUMBER")]
	[StringLength(50)]
	public string AccountNumber { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("ACCOUNT_TYPE_ID")]
	public int AccountTypeId { get; set; }
	
	[Column("CURRENCY_ID")]
	public int CurrencyId { get; set; }
	
	[Column("BALANCE")]
	[Precision(18,2)]
	public decimal Balance { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public AccountStatus Status { get; set; }
	
	[Column("OPENED_DATE")]
	public DateTime OpenedDate { get; set; }
	
	[Column("CLOSED_DATE")]
	public DateTime ClosedDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(AccountStatement.Account))]
	public virtual ICollection<AccountStatement> AccountStatements { get; } = new List<AccountStatement>();


	[InverseProperty(nameof(AccountHolder.Account))]
	public virtual ICollection<AccountHolder> AccountHolders { get; } = new List<AccountHolder>();


	[InverseProperty(nameof(Card.Account))]
	public virtual ICollection<Card> Cards { get; } = new List<Card>();


	[ForeignKey("AccountTypeId")]
	[InverseProperty(nameof(AccountType.Accounts))]
	public virtual AccountType AccountType { get; set; } = null!;


	[ForeignKey("CurrencyId")]
	[InverseProperty(nameof(Currency.Accounts))]
	public virtual Currency Currency { get; set; } = null!;

}

