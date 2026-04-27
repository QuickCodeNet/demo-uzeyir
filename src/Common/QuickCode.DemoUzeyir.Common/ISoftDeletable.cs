using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCode.DemoUzeyir.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}