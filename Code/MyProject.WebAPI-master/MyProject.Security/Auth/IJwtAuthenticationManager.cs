using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Security.Auth
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username,string password);
    }
}
