using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class ChargesTypeMaster
    {
        public int Id { get; set; }
        public decimal NoParkingCharges { get; set; }
        public decimal ExtraTimeCharges { get; set; }
    }
}
