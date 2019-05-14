using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFitnessMonitoring.Models.Identity
{
    //New drived classes 
    public class UserRoleIntPk : IdentityUserRole<int>
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual RoleIntPk Role { get; set; }

    }

    public class UserClaimIntPk : IdentityUserClaim<int>
    {
    }

    public class UserLoginIntPk : IdentityUserLogin<int>
    {
        [Key]
        public int Id { get; set; }
    }

    public class RoleIntPk : IdentityRole<int, UserRoleIntPk>
    {
        public RoleIntPk() { }
        public RoleIntPk(string name) { Name = name; }
    }

    public class UserStoreIntPk : UserStore<ApplicationUser, RoleIntPk, int,
        UserLoginIntPk, UserRoleIntPk, UserClaimIntPk>
    {
        public UserStoreIntPk(FitnessDbContext context)
            : base(context)
        {
        }
    }

    public class RoleStoreIntPk : RoleStore<RoleIntPk, int, UserRoleIntPk>
    {
        public RoleStoreIntPk(FitnessDbContext context)
            : base(context)
        {
        }
    }
}