using Microsoft.AspNetCore.Identity;

namespace StudentManagementApp.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; } = null!;
    }
}
