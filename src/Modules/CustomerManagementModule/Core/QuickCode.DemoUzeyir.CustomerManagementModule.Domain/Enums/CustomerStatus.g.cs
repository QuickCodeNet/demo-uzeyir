using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

public enum CustomerStatus{
	[Description("A potential customer")]
	Prospect,
	[Description("An active customer with one or more accounts")]
	Active,
	[Description("A customer with no active accounts for a period")]
	Inactive,
	[Description("Customer account is temporarily suspended")]
	Suspended,
	[Description("Customer relationship has been terminated")]
	Closed
}
