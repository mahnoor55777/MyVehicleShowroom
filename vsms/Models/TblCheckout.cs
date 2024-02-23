using System;
using System.Collections.Generic;

namespace vsms.Models
{
    public partial class TblCheckout
    {
        public int OrderId { get; set; }
        public string? VNo { get; set; }
        public string? OrderDate { get; set; }
        public string? UserId { get; set; }
    }
}
