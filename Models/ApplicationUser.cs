using Microsoft.AspNetCore.Identity;

namespace ITISchool
{
    public class ApplicationUser:IdentityUser
    {
        public String? Address { get; set; }
    }
}
