using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

public enum StatementFormat{
	[Description("PDF file format")]
	Pdf,
	[Description("Comma-Separated Values format")]
	Csv,
	[Description("Web page format")]
	Html
}
