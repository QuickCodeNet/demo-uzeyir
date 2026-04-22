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

[Table("FEE_TYPES")]
public partial class FeeType : BaseSoftDeletable, IAuditableEntity 
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
	
	[Column("FIXED_AMOUNT")]
	[Precision(18,2)]
	public decimal FixedAmount { get; set; }
	
	[Column("PERCENTAGE_RATE")]
	public decimal PercentageRate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(TransactionFee.FeeType))]
	public virtual ICollection<TransactionFee> TransactionFees { get; } = new List<TransactionFee>();

}

