using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class VehicleTypeMaster
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string EntryFee { get; set; }
        public string NoParkingFee { get; set; }
        public int ExtraTime { get; set; }
        public string ExtraTimeFee { get; set; }
    }
}
