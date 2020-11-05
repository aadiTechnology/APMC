using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class StallRegisterDto
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
        public int ApproveBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ApprovedDate { get; set; }
        [Required]
        public string RejectReason { get; set; }
    }
}
