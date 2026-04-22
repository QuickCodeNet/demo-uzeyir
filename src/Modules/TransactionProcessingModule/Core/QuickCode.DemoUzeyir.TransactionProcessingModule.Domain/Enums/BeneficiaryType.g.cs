using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

public enum BeneficiaryType{
	[Description("Beneficiary account is within the same bank")]
	Internal,
	[Description("Beneficiary account is in another bank")]
	External,
	[Description("Beneficiary account is in a different country")]
	International
}
