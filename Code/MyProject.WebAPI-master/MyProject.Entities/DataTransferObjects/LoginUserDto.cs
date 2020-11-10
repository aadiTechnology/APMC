using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class LoginUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
