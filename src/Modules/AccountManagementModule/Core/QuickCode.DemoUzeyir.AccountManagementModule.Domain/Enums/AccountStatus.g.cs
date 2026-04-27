using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

public enum AccountStatus{
	[Description("Account application is awaiting approval")]
	PendingApproval,
	[Description("Account is open and operational")]
	Active,
	[Description("Account has been inactive for a specified period")]
	Dormant,
	[Description("Account transactions are temporarily blocked")]
	Frozen,
	[Description("Account has been permanently closed")]
	Closed
}
