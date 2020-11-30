using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class EntryCheckInDetailsDto
    {
        public IndentDetails IndentDetails { get; set; }
        public List<ParkingCharges> ParkingCharges { get; set; }
    }
}
