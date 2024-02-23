using System;
using System.Collections.Generic;

namespace vsms.Models
{
    public partial class NewVehicle
    {
        public NewVehicle()
        {
            CustomerOrderItems = new HashSet<CustomerOrderItem>();
        }

        public int VehicleId { get; set; }
        public string? CompanyVehicleName { get; set; }
        public string? CompanyVehicleBrand { get; set; }
        public string? CompanyVehicleModelNum { get; set; }
        public int? CompanyVehiclePrice { get; set; }
        public string? CompanyVehicleImage { get; set; }
        public string? CompanyVehicleColour { get; set; }
        public string? CompanyVehicleDescription { get; set; }

        public virtual ICollection<CustomerOrderItem> CustomerOrderItems { get; set; }
    }
}
