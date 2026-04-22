using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

public enum DocumentStatus{
	[Description("Document submitted, awaiting verification")]
	PendingVerification,
	[Description("Document has been successfully verified")]
	Verified,
	[Description("Document has expired")]
	Expired,
	[Description("Document was rejected during verification")]
	Rejected
}
