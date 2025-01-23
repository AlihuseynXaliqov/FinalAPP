using Microsoft.AspNetCore.Identity;

namespace CakeFinalApp.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
