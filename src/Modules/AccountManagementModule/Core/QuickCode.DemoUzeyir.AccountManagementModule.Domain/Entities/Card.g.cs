using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain;
using QuickCode.DemoUzeyir.Common;
using QuickCode.DemoUzeyir.Common.Auditing;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;

[Table("CARDS")]
public partial class Card : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ACCOUNT_ID")]
	public int AccountId { get; set; }
	
	[Column("CARD_NUMBER")]
	[StringLength(250)]
	public string CardNumber { get; set; }
	
	[Column("CARD_HOLDER_NAME")]
	[StringLength(250)]
	public string CardHolderName { get; set; }
	
	[Column("CARD_TYPE_ID")]
	public int CardTypeId { get; set; }
	
	[Column("EXPIRY_MONTH")]
	public short ExpiryMonth { get; set; }
	
	[Column("EXPIRY_YEAR")]
	public short ExpiryYear { get; set; }
	
	[Column("CVV")]
	[StringLength(50)]
	public string Cvv { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public CardStatus Status { get; set; }
	
	[Column("ACTIVATION_DATE")]
	public DateTime ActivationDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[ForeignKey("AccountId")]
	[InverseProperty(nameof(Account.Cards))]
	public virtual Account Account { get; set; } = null!;


	[ForeignKey("CardTypeId")]
	[InverseProperty(nameof(CardType.Cards))]
	public virtual CardType CardType { get; set; } = null!;

}

