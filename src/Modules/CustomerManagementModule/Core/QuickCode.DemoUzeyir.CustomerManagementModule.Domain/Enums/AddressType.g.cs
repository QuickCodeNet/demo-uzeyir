using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

public enum AddressType{
	[Description("Primary residence address")]
	Residential,
	[Description("Address for sending correspondence")]
	Mailing,
	[Description("Business or work address")]
	Business
}
