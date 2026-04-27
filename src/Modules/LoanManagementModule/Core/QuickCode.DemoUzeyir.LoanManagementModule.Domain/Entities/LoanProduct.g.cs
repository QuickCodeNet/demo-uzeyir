using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;

[Table("LOAN_PRODUCTS")]
public partial class LoanProduct : BaseSoftDeletable, IAuditableEntity 
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
	
	[Column("MIN_AMOUNT")]
	public decimal MinAmount { get; set; }
	
	[Column("MAX_AMOUNT")]
	public decimal MaxAmount { get; set; }
	
	[Column("MIN_TERM_MONTHS")]
	public int MinTermMonths { get; set; }
	
	[Column("MAX_TERM_MONTHS")]
	public int MaxTermMonths { get; set; }
	
	[Column("INTEREST_RATE")]
	public decimal InterestRate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(LoanApplication.LoanProduct))]
	public virtual ICollection<LoanApplication> LoanApplications { get; } = new List<LoanApplication>();

}

