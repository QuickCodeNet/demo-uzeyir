using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

public enum LoanStatus{
	[Description("Loan is disbursed and in repayment")]
	Active,
	[Description("Loan has been fully repaid")]
	PaidOff,
	[Description("Loan is in default due to non-payment")]
	Defaulted,
	[Description("Loan has been written off as a loss")]
	WrittenOff
}
