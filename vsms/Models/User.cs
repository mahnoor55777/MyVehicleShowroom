using System;
using System.Collections.Generic;

namespace vsms.Models
{
    public partial class User
    {
        public User()
        {
            DealerCustomerPurchases = new HashSet<DealerCustomerPurchase>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? UserCity { get; set; }
        public string? UserPassword { get; set; }
        public int? Roles { get; set; }
        public string? UserImage { get; set; }

        public virtual Role? RolesNavigation { get; set; }
        public virtual ICollection<DealerCustomerPurchase> DealerCustomerPurchases { get; set; }
    }
}
