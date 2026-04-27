using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;

[Table("ACCOUNT_STATEMENTS")]
public partial class AccountStatement : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ACCOUNT_ID")]
	public int AccountId { get; set; }
	
	[Column("STATEMENT_PERIOD_START")]
	public DateTime StatementPeriodStart { get; set; }
	
	[Column("STATEMENT_PERIOD_END")]
	public DateTime StatementPeriodEnd { get; set; }
	
	[Column("GENERATED_DATE")]
	public DateTime GeneratedDate { get; set; }
	
	[Column("OPENING_BALANCE")]
	public decimal OpeningBalance { get; set; }
	
	[Column("CLOSING_BALANCE")]
	public decimal ClosingBalance { get; set; }
	
	[Column("STATEMENT_URL")]
	[StringLength(1000)]
	public string StatementUrl { get; set; }
	
	[Column("FORMAT", TypeName = "nvarchar(250)")]
	public StatementFormat Format { get; set; }
	
	[ForeignKey("AccountId")]
	[InverseProperty(nameof(Account.AccountStatements))]
	public virtual Account Account { get; set; } = null!;

}

