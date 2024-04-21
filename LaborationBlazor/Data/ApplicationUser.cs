using LaborationBlazor.Models;
using Microsoft.AspNetCore.Identity;

namespace LaborationBlazor.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public Cart Cart { get; set; }
    }

}
