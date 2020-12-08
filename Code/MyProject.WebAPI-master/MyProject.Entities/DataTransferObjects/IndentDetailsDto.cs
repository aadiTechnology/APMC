using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class IndentDetailsDto
    {
        public IndentDetails IndentDetails { get; set; }
        public List<IndentProducts> IndentProducts { get; set; }
        public AppUsers DriverDetails { get; set; }
        public AppUsers MerchantDetails { get; set; }
        public StallDetails StallDetails { get; set; }
    }
}
