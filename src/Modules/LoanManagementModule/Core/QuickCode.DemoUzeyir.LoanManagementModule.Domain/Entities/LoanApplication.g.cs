using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;

[Table("LOAN_APPLICATIONS")]
public partial class LoanApplication : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("APPLICATION_NUMBER")]
	public Guid ApplicationNumber { get; set; } = Guid.CreateVersion7();
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("LOAN_PRODUCT_ID")]
	public int LoanProductId { get; set; }
	
	[Column("REQUESTED_AMOUNT")]
	[Precision(18,2)]
	public decimal RequestedAmount { get; set; }
	
	[Column("REQUESTED_TERM_MONTHS")]
	public int RequestedTermMonths { get; set; }
	
	[Column("PURPOSE")]
	[StringLength(1000)]
	public string Purpose { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public LoanApplicationStatus Status { get; set; }
	
	[Column("SUBMITTED_DATE")]
	public DateTime SubmittedDate { get; set; }
	
	[Column("DECISION_DATE")]
	public DateTime DecisionDate { get; set; }
	
	[InverseProperty(nameof(Loan.LoanApplication))]
	public virtual ICollection<Loan> Loans { get; } = new List<Loan>();


	[InverseProperty(nameof(Collateral.LoanApplication))]
	public virtual ICollection<Collateral> Collaterals { get; } = new List<Collateral>();


	[ForeignKey("LoanProductId")]
	[InverseProperty(nameof(LoanProduct.LoanApplications))]
	public virtual LoanProduct LoanProduct { get; set; } = null!;

}

