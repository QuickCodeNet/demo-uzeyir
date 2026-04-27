using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;

[Table("CARD_TYPES")]
public partial class CardType : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CODE")]
	[StringLength(50)]
	public string Code { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("NETWORK")]
	[StringLength(50)]
	public string Network { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Card.CardType))]
	public virtual ICollection<Card> Cards { get; } = new List<Card>();

}

