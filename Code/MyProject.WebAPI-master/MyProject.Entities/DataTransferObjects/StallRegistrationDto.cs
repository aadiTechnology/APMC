using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class StallRegistrationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int StallId { get; set; }
        //[Required]
        //public int ProdCategoryId { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        [Required]
        public bool IsRejected { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        //[Required]
        //public int Category { get; set; }

        public int[] Category { get;  set; }

        public int ApproveBy { get; set; }
        public DateTime ApprovedDate { get; set; }    
        public string RejectReason { get; set; }
        
        public string MerchantName { get; set; }
        public string MobileNo { get; set; }

        public string StallNo { get; set; }

        public string StallName { get; set; }

        public string StallRegNo { get; set; }
        public string Area { get; set; }
    }
}
