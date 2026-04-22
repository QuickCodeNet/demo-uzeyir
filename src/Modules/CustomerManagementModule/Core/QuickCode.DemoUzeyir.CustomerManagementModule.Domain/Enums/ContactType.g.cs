using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

public enum ContactType{
	[Description("Primary email address")]
	PrimaryEmail,
	[Description("Secondary email address")]
	SecondaryEmail,
	[Description("Mobile phone number")]
	MobilePhone,
	[Description("Home landline number")]
	HomePhone
}
