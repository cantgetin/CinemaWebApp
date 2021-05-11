using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPcinema.Infrastructure;

namespace ASPcinema.Models
{
    public class RoleAndUsersModel
    {
        public UserRole Role { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}