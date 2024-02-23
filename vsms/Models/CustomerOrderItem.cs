using System;
using System.Collections.Generic;

namespace vsms.Models
{
    public partial class CustomerOrderItem
    {
        public int OrderItemId { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
        public int? VehicleId { get; set; }

        public virtual DealerCustomerPurchase? Order { get; set; }
        public virtual NewVehicle? Vehicle { get; set; }
    }
}
