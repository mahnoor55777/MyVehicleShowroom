using System;
using System.Collections.Generic;

namespace vsms.Models
{
    public partial class CompanyVehicle
    {
        public int CompanyVehicleId { get; set; }
        public string? CompanyVehicleName { get; set; }
        public string? CompanyVehicleBrand { get; set; }
        public string? CompanyVehicleModelNum { get; set; }
        public int? CompanyVehiclePrice { get; set; }
        public string? CompanyVehicleImage { get; set; }
        public string? CompanyVehicleColour { get; set; }
        public string? CompanyVehicleDescription { get; set; }
        public string? Status { get; set; }
    }
}
