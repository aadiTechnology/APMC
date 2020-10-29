using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class StallDetails
    {
        public int Id { get; set; }
        public string StallNo { get; set; }
        public string StallName { get; set; }
        public string StallRegNo { get; set; }
        public string Area { get; set; }
        public bool IsAssigned { get; set; }
    }
}
