using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoUzeyir.Common;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}