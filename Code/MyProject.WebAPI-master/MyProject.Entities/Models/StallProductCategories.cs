using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class StallProductCategories
    {
        public int Id { get; set; }
        public int StallRegistrationId { get; set; }
        public int Category { get; set; }
       // public int[] Category { get; private set; }
    }
}
