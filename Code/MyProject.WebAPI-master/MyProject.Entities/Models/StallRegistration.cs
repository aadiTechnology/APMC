using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class StallRegistration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StallId { get; set; }

        //public int ProdCategoryId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public int ApproveBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string RejectReason { get; set; }

    }
}
