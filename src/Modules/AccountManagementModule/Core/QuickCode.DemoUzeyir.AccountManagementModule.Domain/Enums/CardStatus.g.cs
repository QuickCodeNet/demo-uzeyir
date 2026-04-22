using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

public enum CardStatus{
	[Description("Card is active and can be used")]
	Active,
	[Description("Card is not yet activated")]
	Inactive,
	[Description("Card is temporarily blocked")]
	Blocked,
	[Description("Card has passed its expiry date")]
	Expired,
	[Description("Card has been reported as lost or stolen")]
	LostStolen
}
