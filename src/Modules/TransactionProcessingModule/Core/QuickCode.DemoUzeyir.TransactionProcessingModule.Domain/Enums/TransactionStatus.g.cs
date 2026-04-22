using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

public enum TransactionStatus{
	[Description("Transaction is initiated but not yet processed")]
	Pending,
	[Description("Transaction was successfully processed")]
	Completed,
	[Description("Transaction failed due to an error")]
	Failed,
	[Description("Transaction was cancelled by the user or system")]
	Cancelled,
	[Description("Transaction was reversed")]
	Reversed
}
