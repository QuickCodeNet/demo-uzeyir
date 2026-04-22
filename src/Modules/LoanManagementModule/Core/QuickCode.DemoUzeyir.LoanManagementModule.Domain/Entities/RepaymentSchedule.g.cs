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

[Table("REPAYMENT_SCHEDULES")]
public partial class RepaymentSchedule : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("LOAN_ID")]
	public int LoanId { get; set; }
	
	[Column("INSTALLMENT_NUMBER")]
	public int InstallmentNumber { get; set; }
	
	[Column("DUE_DATE")]
	public DateTime DueDate { get; set; }
	
	[Column("PRINCIPAL_AMOUNT")]
	[Precision(18,2)]
	public decimal PrincipalAmount { get; set; }
	
	[Column("INTEREST_AMOUNT")]
	[Precision(18,2)]
	public decimal InterestAmount { get; set; }
	
	[Column("TOTAL_AMOUNT")]
	[Precision(18,2)]
	public decimal TotalAmount { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public PaymentStatus Status { get; set; }
	
	[InverseProperty(nameof(LoanPayment.RepaymentSchedule))]
	public virtual ICollection<LoanPayment> LoanPayments { get; } = new List<LoanPayment>();


	[ForeignKey("LoanId")]
	[InverseProperty(nameof(Loan.RepaymentSchedules))]
	public virtual Loan Loan { get; set; } = null!;

}

