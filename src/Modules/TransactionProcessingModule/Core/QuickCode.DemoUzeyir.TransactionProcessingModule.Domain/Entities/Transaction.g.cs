using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;

[Table("TRANSACTIONS")]
public partial class Transaction : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public long Id { get; set; }
	
	[Column("TRANSACTION_REFERENCE")]
	public Guid TransactionReference { get; set; } = Guid.CreateVersion7();
	
	[Column("SOURCE_ACCOUNT_ID")]
	public int? SourceAccountId { get; set; }
	
	[Column("DESTINATION_ACCOUNT_ID")]
	public int? DestinationAccountId { get; set; }
	
	[Column("TRANSACTION_TYPE_ID")]
	public int TransactionTypeId { get; set; }
	
	[Column("TRANSACTION_CHANNEL_ID")]
	public int TransactionChannelId { get; set; }
	
	[Column("AMOUNT")]
	public decimal Amount { get; set; }
	
	[Column("CURRENCY_CODE")]
	[StringLength(50)]
	public string CurrencyCode { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public TransactionStatus Status { get; set; }
	
	[Column("TRANSACTION_DATE")]
	public DateTime TransactionDate { get; set; }
	
	[Column("COMPLETED_DATE")]
	public DateTime CompletedDate { get; set; }
	
	[InverseProperty(nameof(TransactionFee.Transaction))]
	public virtual ICollection<TransactionFee> TransactionFees { get; } = new List<TransactionFee>();


	[ForeignKey("TransactionTypeId")]
	[InverseProperty(nameof(TransactionType.Transactions))]
	public virtual TransactionType TransactionType { get; set; } = null!;


	[ForeignKey("TransactionChannelId")]
	[InverseProperty(nameof(TransactionChannel.Transactions))]
	public virtual TransactionChannel TransactionChannel { get; set; } = null!;

}

