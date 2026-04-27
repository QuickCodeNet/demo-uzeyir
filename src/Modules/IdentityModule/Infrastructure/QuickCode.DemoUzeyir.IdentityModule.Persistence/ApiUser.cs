using Microsoft.AspNetCore.Identity;

namespace QuickCode.DemoUzeyir.IdentityModule.Persistence;

public class ApiUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PermissionGroupName { get; set; }
}
