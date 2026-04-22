using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

public enum TransferStatus{
	[Description("Transfer is scheduled for a future date")]
	Scheduled,
	[Description("Transfer requires approval before processing")]
	PendingApproval,
	[Description("Transfer is currently being processed")]
	InProgress,
	[Description("Transfer was successfully completed")]
	Completed,
	[Description("Transfer failed")]
	Failed
}
