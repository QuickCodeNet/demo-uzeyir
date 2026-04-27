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

[Table("PENDING_TRANSFERS")]
public partial class PendingTransfer : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("TRANSFER_REFERENCE")]
	public Guid TransferReference { get; set; } = Guid.CreateVersion7();
	
	[Column("SOURCE_ACCOUNT_ID")]
	public int SourceAccountId { get; set; }
	
	[Column("BENEFICIARY_ID")]
	public int BeneficiaryId { get; set; }
	
	[Column("AMOUNT")]
	public decimal Amount { get; set; }
	
	[Column("SCHEDULED_DATE")]
	public DateTime ScheduledDate { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public TransferStatus Status { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[ForeignKey("BeneficiaryId")]
	[InverseProperty(nameof(Beneficiary.PendingTransfers))]
	public virtual Beneficiary Beneficiary { get; set; } = null!;

}

