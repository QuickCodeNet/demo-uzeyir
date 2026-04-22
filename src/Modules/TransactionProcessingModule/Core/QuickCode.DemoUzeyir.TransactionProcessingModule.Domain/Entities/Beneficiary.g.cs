using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;

[Table("BENEFICIARIES")]
public partial class Beneficiary : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("NICKNAME")]
	[StringLength(250)]
	public string Nickname { get; set; }
	
	[Column("BENEFICIARY_ACCOUNT_NUMBER")]
	[StringLength(250)]
	public string BeneficiaryAccountNumber { get; set; }
	
	[Column("BENEFICIARY_NAME")]
	[StringLength(250)]
	public string BeneficiaryName { get; set; }
	
	[Column("BANK_NAME")]
	[StringLength(250)]
	public string BankName { get; set; }
	
	[Column("BANK_CODE")]
	[StringLength(50)]
	public string BankCode { get; set; }
	
	[Column("TYPE", TypeName = "nvarchar(250)")]
	public BeneficiaryType Type { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(PendingTransfer.Beneficiary))]
	public virtual ICollection<PendingTransfer> PendingTransfers { get; } = new List<PendingTransfer>();

}

