using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;

[Table("COLLATERALS")]
public partial class Collateral : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("LOAN_APPLICATION_ID")]
	public int LoanApplicationId { get; set; }
	
	[Column("COLLATERAL_TYPE_ID")]
	public int CollateralTypeId { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("MARKET_VALUE")]
	public decimal MarketValue { get; set; }
	
	[Column("VALUATION_DATE")]
	public DateTime ValuationDate { get; set; }
	
	[ForeignKey("LoanApplicationId")]
	[InverseProperty(nameof(LoanApplication.Collaterals))]
	public virtual LoanApplication LoanApplication { get; set; } = null!;


	[ForeignKey("CollateralTypeId")]
	[InverseProperty(nameof(CollateralType.Collaterals))]
	public virtual CollateralType CollateralType { get; set; } = null!;

}

