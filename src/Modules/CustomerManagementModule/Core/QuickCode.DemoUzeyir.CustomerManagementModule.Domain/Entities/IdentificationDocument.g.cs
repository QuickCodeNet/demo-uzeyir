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

[Table("IDENTIFICATION_DOCUMENTS")]
public partial class IdentificationDocument : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CUSTOMER_ID")]
	public int CustomerId { get; set; }
	
	[Column("DOCUMENT_TYPE_ID")]
	public int DocumentTypeId { get; set; }
	
	[Column("DOCUMENT_NUMBER")]
	[StringLength(250)]
	public string DocumentNumber { get; set; }
	
	[Column("ISSUE_DATE")]
	public DateTime IssueDate { get; set; }
	
	[Column("EXPIRY_DATE")]
	public DateTime ExpiryDate { get; set; }
	
	[Column("ISSUING_COUNTRY")]
	[StringLength(50)]
	public string IssuingCountry { get; set; }
	
	[Column("DOCUMENT_URL")]
	[StringLength(500)]
	public string DocumentUrl { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public DocumentStatus Status { get; set; }
	
	[ForeignKey("CustomerId")]
	[InverseProperty(nameof(Customer.IdentificationDocuments))]
	public virtual Customer Customer { get; set; } = null!;


	[ForeignKey("DocumentTypeId")]
	[InverseProperty(nameof(DocumentType.IdentificationDocuments))]
	public virtual DocumentType DocumentType { get; set; } = null!;

}

