using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;

[Table("TRANSACTION_FEES")]
public partial class TransactionFee : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("TRANSACTION_ID")]
	public long TransactionId { get; set; }
	
	[Column("FEE_TYPE_ID")]
	public int FeeTypeId { get; set; }
	
	[Column("FEE_AMOUNT")]
	[Precision(18,2)]
	public decimal FeeAmount { get; set; }
	
	[Column("APPLIED_DATE")]
	public DateTime AppliedDate { get; set; }
	
	[ForeignKey("TransactionId")]
	[InverseProperty(nameof(Transaction.TransactionFees))]
	public virtual Transaction Transaction { get; set; } = null!;


	[ForeignKey("FeeTypeId")]
	[InverseProperty(nameof(FeeType.TransactionFees))]
	public virtual FeeType FeeType { get; set; } = null!;

}

