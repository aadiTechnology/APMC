using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class IndentDetails
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string ETADate { get; set; }
        public string ETATime { get; set; }
        public string VehicleNo { get; set; }
        public string SupplierNo { get; set; }
        public string SupplierName { get; set; }
        public string DriverName { get; set; }
        public string DriverNo { get; set; }
        public int? RollId { get; set; }
        public int? CreatedBy { get; set; }
        public int AppovedBy { get; set; }
        public bool IsApprove { get; set; }
        public bool IsRejected { get; set; }
        public string RejectReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public string QrId { get; set; }
        public bool IsScanned { get; set; }
    }
}
