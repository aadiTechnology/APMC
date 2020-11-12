using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
