using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

public enum LoanApplicationStatus{
	[Description("Application started but not submitted")]
	Draft,
	[Description("Application submitted and pending review")]
	Submitted,
	[Description("Application is being reviewed by underwriting")]
	UnderReview,
	[Description("Application has been approved")]
	Approved,
	[Description("Application has been rejected")]
	Rejected,
	[Description("Application was withdrawn by the customer")]
	Withdrawn
}
