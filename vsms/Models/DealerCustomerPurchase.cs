using System;
using System.Collections.Generic;

namespace vsms.Models
{
    public partial class DealerCustomerPurchase
    {
        public DealerCustomerPurchase()
        {
            CustomerOrderItems = new HashSet<CustomerOrderItem>();
        }

        public int DcpId { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public int? TotaleOrderPrice { get; set; }
        public int? UId { get; set; }

        public virtual User? UIdNavigation { get; set; }
        public virtual ICollection<CustomerOrderItem> CustomerOrderItems { get; set; }
    }
}
