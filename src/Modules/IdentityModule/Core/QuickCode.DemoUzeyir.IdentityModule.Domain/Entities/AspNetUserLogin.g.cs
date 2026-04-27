using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.IdentityModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.IdentityModule.Domain.Entities;

[Table("AspNetUserLogins")]
public partial class AspNetUserLogin : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("LoginProvider")]
	[StringLength(450)]
	public string LoginProvider { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("ProviderKey")]
	[StringLength(450)]
	public string ProviderKey { get; set; }
	
	[Column("ProviderDisplayName")]
	[StringLength(int.MaxValue)]
	public string? ProviderDisplayName { get; set; }
	
	[Column("UserId")]
	[StringLength(450)]
	public string UserId { get; set; }
	
	[ForeignKey("UserId")]
	[InverseProperty(nameof(AspNetUser.AspNetUserLogins))]
	public virtual AspNetUser AspNetUser { get; set; } = null!;

}

