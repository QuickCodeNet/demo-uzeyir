using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

public enum PaymentStatus{
	[Description("Payment is scheduled but not yet due")]
	Scheduled,
	[Description("Payment was made successfully")]
	Paid,
	[Description("Payment is past its due date")]
	Overdue,
	[Description("A partial payment was made")]
	PartiallyPaid
}
