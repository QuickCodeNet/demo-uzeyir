using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;

[Table("ADDRESSES")]
public partial class Address : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("ADDRESS_LINE_1")]
	[StringLength(250)]
	public string AddressLine1 { get; set; }
	
	[Column("ADDRESS_LINE_2")]
	[StringLength(250)]
	public string AddressLine2 { get; set; }
	
	[Column("CITY")]
	[StringLength(250)]
	public string City { get; set; }
	
	[Column("STATE")]
	[StringLength(250)]
	public string State { get; set; }
	
	[Column("POSTAL_CODE")]
	[StringLength(50)]
	public string PostalCode { get; set; }
	
	[Column("COUNTRY_CODE")]
	[StringLength(50)]
	public string CountryCode { get; set; }
	
	[Column("TYPE", TypeName = "nvarchar(250)")]
	public AddressType Type { get; set; }
	
	[Column("IS_PRIMARY")]
	public bool IsPrimary { get; set; }
	
	[ForeignKey("CustomerId")]
	[InverseProperty(nameof(Customer.Addresses))]
	public virtual Customer Customer { get; set; } = null!;

}

