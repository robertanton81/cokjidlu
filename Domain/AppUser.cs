namespace Domain
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
