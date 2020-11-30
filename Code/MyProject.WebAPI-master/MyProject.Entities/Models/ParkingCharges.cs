using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class ParkingCharges
    {
        public int Id { get; set; }
        public string IndentId { get; set; }
        public string VehicleTypeId { get; set; }
        public string VehicleNumber { get; set; }
        public string EntryFee { get; set; }
        public int ChargesTypeId { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
       
    }
}
