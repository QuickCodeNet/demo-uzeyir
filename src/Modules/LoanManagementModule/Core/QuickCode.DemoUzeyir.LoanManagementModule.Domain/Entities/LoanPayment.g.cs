using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;

[Table("LOAN_PAYMENTS")]
public partial class LoanPayment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("LOAN_ID")]
	public int LoanId { get; set; }
	
	[Column("SCHEDULE_ID")]
	public int ScheduleId { get; set; }
	
	[Column("PAYMENT_REFERENCE")]
	public Guid PaymentReference { get; set; } = Guid.CreateVersion7();
	
	[Column("AMOUNT_PAID")]
	[Precision(18,2)]
	public decimal AmountPaid { get; set; }
	
	[Column("PAYMENT_DATE")]
	public DateTime PaymentDate { get; set; }
	
	[Column("PAYMENT_METHOD")]
	[StringLength(50)]
	public string PaymentMethod { get; set; }
	
	[ForeignKey("LoanId")]
	[InverseProperty(nameof(Loan.LoanPayments))]
	public virtual Loan Loan { get; set; } = null!;


	[ForeignKey("ScheduleId")]
	[InverseProperty(nameof(RepaymentSchedule.LoanPayments))]
	public virtual RepaymentSchedule RepaymentSchedule { get; set; } = null!;

}

