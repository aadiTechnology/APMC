using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class EntryCheckInDetailsDto
    {
        public int IndentId { get; set; }
        public string OrderNo { get; set; }
        public string StallCreatedBy { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNo { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }
        public string DriverNo { get; set; }
        public string ETADate { get; set; }
        public string ETATime { get; set; }
        public string StallNo { get; set; }
        public string StallName { get; set; }
        public List<InedntProducts> Products { get; set; }
        public IndentDetails IndentDetails { get; set; }
        public ParkingCharges ParkingCharges { get; set; }
    }

    public class InedntProducts
    {
        public string ProductCategory { get; set; }
        public string ProductName { get; set; }
        public string ProductQuantity { get; set; }
        public string Unit { get; set; }
    }
}
