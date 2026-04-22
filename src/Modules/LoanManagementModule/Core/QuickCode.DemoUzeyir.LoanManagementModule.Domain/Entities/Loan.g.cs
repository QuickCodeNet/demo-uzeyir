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

[Table("LOANS")]
public partial class Loan : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("LOAN_ACCOUNT_NUMBER")]
	[StringLength(50)]
	public string LoanAccountNumber { get; set; }
	
	[Column("APPLICATION_ID")]
	public int ApplicationId { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("PRINCIPAL_AMOUNT")]
	[Precision(18,2)]
	public decimal PrincipalAmount { get; set; }
	
	[Column("OUTSTANDING_BALANCE")]
	[Precision(18,2)]
	public decimal OutstandingBalance { get; set; }
	
	[Column("INTEREST_RATE")]
	public decimal InterestRate { get; set; }
	
	[Column("TERM_MONTHS")]
	public int TermMonths { get; set; }
	
	[Column("DISBURSEMENT_DATE")]
	public DateTime DisbursementDate { get; set; }
	
	[Column("MATURITY_DATE")]
	public DateTime MaturityDate { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public LoanStatus Status { get; set; }
	
	[InverseProperty(nameof(RepaymentSchedule.Loan))]
	public virtual ICollection<RepaymentSchedule> RepaymentSchedules { get; } = new List<RepaymentSchedule>();


	[InverseProperty(nameof(LoanPayment.Loan))]
	public virtual ICollection<LoanPayment> LoanPayments { get; } = new List<LoanPayment>();


	[ForeignKey("ApplicationId")]
	[InverseProperty(nameof(LoanApplication.Loans))]
	public virtual LoanApplication LoanApplication { get; set; } = null!;

}

