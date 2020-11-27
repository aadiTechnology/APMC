using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class AppUserRoles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

    }
    public enum Roles
    {
        Admin = 1,
        Merchant = 2,
        Driver = 3,
        Agent = 5,
        Transporter = 6,
        EntryGateOperator = 7,
        ExitGateOperator = 8
    }
}

